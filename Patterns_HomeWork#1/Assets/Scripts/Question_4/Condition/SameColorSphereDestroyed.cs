
public class SameColorSphereDestroyed : VictoryCondition {
    public Sphere Sphere { get; private set; }

    public SameColorSphereDestroyed(Sphere sphere) {
        Sphere = sphere;
    }
}
