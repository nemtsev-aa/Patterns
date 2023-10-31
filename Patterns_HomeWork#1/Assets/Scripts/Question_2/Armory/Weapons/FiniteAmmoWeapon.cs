using System;

public class FiniteAmmoWeapon : Weapon {
    private BulletCounter _bulletCounter;

    public BulletCounter BulletCounter => _bulletCounter;
    public int CurrentAmmo => _bulletCounter.NumberOfBullets;

    public event Action<int> Activated;

    public override void Init() {
        base.Init();
        _bulletCounter = new BulletCounter(_config.MaxAmmo);
    }

    public override void Activate() {
        base.Activate();
        Activated?.Invoke(CurrentAmmo);
    }

    protected override bool CheckBulletCount() {
        
        if (_bulletCounter.NumberOfBullets == 0)
            return false;
        else
            return true;
    }

    protected override void TakeBullets(int number) => _bulletCounter.TakeBullets(number);

}