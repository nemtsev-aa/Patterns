using System;
using UnityEngine;

public enum WeaponStatus {
    Ready,
    Reload,
    NoBullets
}

public abstract class Weapon : MonoBehaviour {
    public BulletCounter BulletCounter => _bulletCounter;

    [Tooltip("Идентификатор оружия")]
    [SerializeField] protected int _weaponID;
    [Tooltip("Скорострельность")]
    [SerializeField] protected float _shotPeriod = 0.2f;
    [Tooltip("Счётчик пуль")]
    [SerializeField] protected BulletCounter _bulletCounter;
    [Tooltip("Генератор пуль")]
    [SerializeField] protected BulletCreator _bulletCreator;

    public Action OnShot;

    private float _timer;
    protected float _lastShootTime;

    public void Init() {
        _bulletCreator.Init();
    }

    public WeaponStatus CheckWeaponStatus() {
        if (Time.time - _lastShootTime < _shotPeriod) return WeaponStatus.Reload;
        if (_bulletCounter.NumberOfBullets == 0) return WeaponStatus.NoBullets;
        return WeaponStatus.Ready;
    }

    public abstract void Shoot();

    public virtual void Activate() {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate() {
        gameObject.SetActive(false);
    }
}
