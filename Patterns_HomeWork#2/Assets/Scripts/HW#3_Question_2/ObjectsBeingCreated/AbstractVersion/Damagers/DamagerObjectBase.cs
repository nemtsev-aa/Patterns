public class DamagerObjectBase : ObjectBase {
    protected IDamage  Damager;

    public DamagerObjectBase(DamagerConfig objectConfig) {
        Config = objectConfig;
    }

    protected DamagerConfig Config { get; private set; }

    protected override void GetPrefab() {
        Trigger = Instantiate(Config.Prefab.gameObject);
    }

    protected override void SetEffect() {
        Damager = new InstantDamager(Config.Value, Config.TimeDuartion);
        Trigger.GetComponent<DamageTrigger>().SetDamager(Damager);
    }
}
