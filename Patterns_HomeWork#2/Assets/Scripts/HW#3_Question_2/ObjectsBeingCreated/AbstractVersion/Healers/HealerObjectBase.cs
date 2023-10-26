public class HealerObjectBase : ObjectBase {
    protected IHealth Healer;

    public HealerObjectBase(HealerConfig objectConfig) {
        Config = objectConfig;
    }

    protected HealerConfig Config { get; private set; }

    protected override void GetPrefab() {
        Trigger = Instantiate(Config.Prefab.gameObject);
    }

    protected override void SetEffect() {
        Healer = new InstantHealer(Config.Value, Config.TimeDuartion);
        Trigger.GetComponent<HealingTrigger>().SetHealer(Healer);
    }
}