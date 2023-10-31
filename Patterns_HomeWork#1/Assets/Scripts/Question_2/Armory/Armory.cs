using System;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour {
    [SerializeField] private int _defaultGunIndex = 0;
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private ArmoryView _armoryView;

    private Controller _controller;
    private WeaponSwitcher _weaponSwitcher;

    public IReadOnlyList<Weapon> Weapons => _weapons;
    public WeaponSwitcher WeaponSwitcher => _weaponSwitcher;
    
    public void Init(Controller controller) {
        _controller = controller;

        WeaponsInit();

        _weaponSwitcher = new WeaponSwitcher(Weapons, _controller);
        _armoryView.Init(Weapons, _weaponSwitcher);
        _weaponSwitcher.SetWeaponById(_defaultGunIndex);
    }
    
    private void WeaponsInit() {
        if (_weapons.Count == 0) {
            throw new ArgumentNullException($"Weapons List is empty");
        }

        foreach (Weapon iWeapon in _weapons) {
            iWeapon.Init();
        }
    }
}
