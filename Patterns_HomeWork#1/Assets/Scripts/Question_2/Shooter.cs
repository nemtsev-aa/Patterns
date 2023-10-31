using System;

public class Shooter : IDisposable {
    private Armory _armory;
    private Controller _controller;

    public Shooter(Controller controller, Armory armory) {
        _controller = controller;
        _armory = armory;

        ÑreateSubscriptions();
    }

    public Weapon ActiveWeapon => _armory.WeaponSwitcher.ActiveWeapon;

    public void Shoot() {
        ActiveWeapon.CheckWeaponStatus(out WeaponStatus currentStatus);

        if (currentStatus == WeaponStatus.Ready)
            ActiveWeapon.Shoot();
    }

    public void AddBullets(int gunIndex, int numberOfBullets) {
        if (gunIndex > _armory.Weapons.Count)
            throw new ArgumentOutOfRangeException($"Invalid GunIndex {gunIndex}");

        if (_armory.Weapons[gunIndex] is FiniteAmmoWeapon) {
            FiniteAmmoWeapon weapon = (FiniteAmmoWeapon)_armory.Weapons[gunIndex];
            weapon.BulletCounter.AddBullets(numberOfBullets);
        }
    }

    private void ÑreateSubscriptions() {
        _controller.MouseLeftClicked += Shoot;
    }

    public void Dispose() {
        _controller.MouseLeftClicked -= Shoot;
    }
}
