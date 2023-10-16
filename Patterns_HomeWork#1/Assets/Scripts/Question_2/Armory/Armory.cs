using System;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour {
    public Weapon ActiveWeapon => _activeWeapon;

    public Action<int> OnActiveWeaponChanged;

   [Tooltip("Список оружия")]
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [Tooltip("Виджет")]
    [SerializeField] private ArmoryView _armoryView;

    private int _currentGunIndex = 0;
    private Weapon _activeWeapon;

    private void Start() {
        TakeGunByIndex(_currentGunIndex);
        foreach (Weapon iWeapon in _weapons) {
            iWeapon.Init();
            iWeapon.BulletCounter.OnBulletsCountChanged += _armoryView.UpdateBulletsCount;
        }

        OnActiveWeaponChanged += _armoryView.UpdateSelectionWeaponIcon;
    }

    public void TryShoot() {
        WeaponStatus currentStatus = _activeWeapon.CheckWeaponStatus();
        if (currentStatus == WeaponStatus.Ready) {
            _activeWeapon.Shoot();
        } else if (currentStatus == WeaponStatus.NoBullets) {
            SetWeaponID(true);
        }
    }

    public void SendWeaponID(KeyCode keyCode) {
        //int currentID = _playerArmory.CurrentWeaponID;
        switch (keyCode) {
            case KeyCode.Alpha1:
                SetWeaponID(0);
                break;
            case KeyCode.Alpha2:
                SetWeaponID(1);
                break;
            case KeyCode.Alpha3:
                SetWeaponID(2);
                break;
            case KeyCode.Alpha4:
                SetWeaponID(3);
                break;
            default:
                break;
        }
    }

    public void SendWeaponID(bool scrollWheel) {
        SetWeaponID(scrollWheel);
    }

    public void AddBullets(int gunIndex, int numberOfBullets) {
        _weapons[gunIndex].BulletCounter.AddBullets(numberOfBullets);
    }

    private void SetWeaponID(int id) {
        TakeGunByIndex(id);
    }

    private void SetWeaponID(bool value) {
        if (value) {
            if (_currentGunIndex == _weapons.Count - 1) _currentGunIndex = 0;
            else _currentGunIndex++;
        }
        else {
            if (_currentGunIndex == 0) _currentGunIndex = _weapons.Count - 1;
            else _currentGunIndex--;
        }
        TakeGunByIndex(_currentGunIndex);
    }

    private void TakeGunByIndex(int gunIndex) {
        if (_activeWeapon != null) _activeWeapon.Deactivate();
        
        _currentGunIndex = gunIndex;
        _activeWeapon = _weapons[_currentGunIndex];
        _activeWeapon.Activate();

        OnActiveWeaponChanged?.Invoke(_currentGunIndex);
    }
}
