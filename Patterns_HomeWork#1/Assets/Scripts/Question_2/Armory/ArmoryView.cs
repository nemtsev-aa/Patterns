using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ArmoryView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _bulletsCountText;
    [SerializeField] private Toggle[] _weaponsIcon;
    private IReadOnlyList<Weapon> _weapons;
    private WeaponSwitcher _weaponSwitcher;

    public void Init(IReadOnlyList<Weapon> weapons, WeaponSwitcher weaponSwitcher) {
        _weapons = weapons;
        _weaponSwitcher = weaponSwitcher;

        ÑreateSubscriptions();
    }

    private void ÑreateSubscriptions() {
        _weaponSwitcher.ActiveWeaponChanged += UpdateSelectionWeaponIcon;

        foreach (Weapon iWeapon in _weapons) {
            
            if (iWeapon is FiniteAmmoWeapon) {
                FiniteAmmoWeapon finiteAmmoWeapon = (FiniteAmmoWeapon)iWeapon;
                finiteAmmoWeapon.Activated += UpdateBulletsCount;
                finiteAmmoWeapon.BulletCounter.BulletsCountChanged += UpdateBulletsCount;
            }

            if (iWeapon is InfiniteAmmoWeapon) {
                InfiniteAmmoWeapon infiniteAmmoWeapon = (InfiniteAmmoWeapon)iWeapon;
                infiniteAmmoWeapon.Activated += ShowInfiniteChar;
            }
        }
    }

    private void UpdateSelectionWeaponIcon(Weapon weapon) {
        _weaponsIcon[weapon.Config.WeaponID].isOn = true;

        if (weapon is FiniteAmmoWeapon) {
            FiniteAmmoWeapon finiteAmmoWeapon = (FiniteAmmoWeapon)weapon;

            UpdateBulletsCount(finiteAmmoWeapon.CurrentAmmo);
        } 
    }

    private void UpdateBulletsCount(int bulletCount) => _bulletsCountText.text = $"{bulletCount}";

    private void ShowInfiniteChar(string infiniteChar) => _bulletsCountText.text = $"{infiniteChar}";

    private void OnDisable() {
        _weaponSwitcher.ActiveWeaponChanged -= UpdateSelectionWeaponIcon;

        foreach (Weapon iWeapon in _weapons) {

            if (iWeapon is FiniteAmmoWeapon) {
                FiniteAmmoWeapon finiteAmmoWeapon = (FiniteAmmoWeapon)iWeapon;
                finiteAmmoWeapon.BulletCounter.BulletsCountChanged -= UpdateBulletsCount;
            }

            if (iWeapon is InfiniteAmmoWeapon) {
                InfiniteAmmoWeapon infiniteAmmoWeapon = (InfiniteAmmoWeapon)iWeapon;
                infiniteAmmoWeapon.Activated -= ShowInfiniteChar;
            }
        }
    }
}
