using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    [SerializeField] protected WeaponConfig _config;
    [SerializeField] private List<Transform> _bulletCreatorPoints = new List<Transform>();

    private float _lastShootTime;

    public WeaponConfig Config => _config;

    public virtual void Init() { }

    public void Shoot() {
        _lastShootTime = Time.time;
        CreateBullets();
    }

    public void CheckWeaponStatus(out WeaponStatus status) {
        status = WeaponStatus.Reload;

        if (Time.time - _lastShootTime < _config.ShotPeriod) {
            status = WeaponStatus.Reload;
            return;
        }

        if (CheckBulletCount() == false)
            status = WeaponStatus.NoBullets;
        else
            status = WeaponStatus.Ready;
    }

    public virtual void Activate() => gameObject.SetActive(true);

    public void Deactivate() => gameObject.SetActive(false);
    
    protected abstract bool CheckBulletCount();
    
    protected abstract void TakeBullets(int number);
    
    private void CreateBullets() {
        Vector3 velocity = transform.forward;

        foreach (var iPoint in _bulletCreatorPoints) {
            Bullet newBullet = _config.BulletFactory.Get(_config.BulletType);
            newBullet.transform.position = iPoint.position;
            newBullet.SetVelocity(velocity);
        }

        TakeBullets(_bulletCreatorPoints.Count);
    }
}
