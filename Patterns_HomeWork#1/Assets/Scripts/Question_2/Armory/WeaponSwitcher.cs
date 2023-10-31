using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : IDisposable {
    private const int Gun = 0;
    private const int AssaultRifle = 1;
    private const int Shotgun = 2;

    private Controller _controller;
    private IReadOnlyList<Weapon> _weapons;

    private int _currentGunIndex;
    private Weapon _activeWeapon;

    public WeaponSwitcher(IReadOnlyList<Weapon> weapons, Controller controller, int currentGunIndex = 0) {
        _weapons = weapons;
        _controller = controller;
        _currentGunIndex = currentGunIndex;

        СreateSubscriptions();

        SetWeaponById(currentGunIndex);
    }

    public Weapon ActiveWeapon => _activeWeapon;

    public event Action<Weapon> ActiveWeaponChanged;

    public void SetWeaponById(int gunIndex) {
        if (_activeWeapon != null)
            _activeWeapon.Deactivate();

        _currentGunIndex = gunIndex;
        _activeWeapon = _weapons[_currentGunIndex];
        _activeWeapon.Activate();

        ActiveWeaponChanged?.Invoke(_activeWeapon);
    }

    public void Dispose() {
        _controller.KeyDown -= SwitchById;
        _controller.MouseScrolled -= SwitchByScroll;

        foreach (Weapon iWeapon in _weapons) {
            if (iWeapon is FiniteAmmoWeapon) {
                FiniteAmmoWeapon finiteAmmoWeapon = (FiniteAmmoWeapon)iWeapon;
                finiteAmmoWeapon.BulletCounter.BulletsOut -= GetNextGunIndex;
            }
        }
    }

    private void СreateSubscriptions() {
        _controller.KeyDown += SwitchById;
        _controller.MouseScrolled += SwitchByScroll;

        foreach (Weapon iWeapon in _weapons) {
            if (iWeapon is FiniteAmmoWeapon) {
                FiniteAmmoWeapon finiteAmmoWeapon = (FiniteAmmoWeapon)iWeapon;
                finiteAmmoWeapon.BulletCounter.BulletsOut += GetNextGunIndex;
            }
        }
    }

    private void SwitchById(KeyCode keyCode) {

        switch (keyCode) {
            case KeyCode.Alpha1:
                SetWeaponById(Gun);
                break;

            case KeyCode.Alpha2:
                SetWeaponById(AssaultRifle);
                break;

            case KeyCode.Alpha3:
                SetWeaponById(Shotgun);
                break;

            default:
                throw new ArgumentNullException($"KeyCode error");
        }
    }

    private void SwitchByScroll(bool value) {
        if (value)
            GetNextGunIndex();
        else
            GetPreviousGunIndex();
    }

    private void GetPreviousGunIndex() {
        if (_currentGunIndex == 0)
            _currentGunIndex = _weapons.Count - 1;
        else 
            _currentGunIndex--;

        SetWeaponById(_currentGunIndex);
    }

    private void GetNextGunIndex() {
        if (_currentGunIndex == _weapons.Count - 1)
            _currentGunIndex = 0;
        else
            _currentGunIndex++;

        SetWeaponById(_currentGunIndex);
    }
}