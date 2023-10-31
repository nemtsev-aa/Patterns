using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon/WeaponConfig")]
public class WeaponConfig : ScriptableObject {
    [SerializeField] protected int _weaponID;
    [SerializeField] protected float _shotPeriod = 0.2f;
    [SerializeField] protected int _maxAmmo;
    [SerializeField] private BulletTypes _bulletType;
    [SerializeField] protected BulletFactory _bulletFactory;

    public int WeaponID => _weaponID;
    public float ShotPeriod => _shotPeriod;
    public int MaxAmmo => _maxAmmo;
    public BulletTypes BulletType {
        get { return _bulletType; }
        set { value = _bulletType; }
    }
    public BulletFactory BulletFactory => _bulletFactory;

}