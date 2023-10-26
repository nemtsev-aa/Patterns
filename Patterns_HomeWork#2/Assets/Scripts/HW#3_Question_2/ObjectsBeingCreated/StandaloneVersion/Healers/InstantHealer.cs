public class InstantHealer : IHealth {
    private int _health;
    private float _timeDuration = 0;

    public InstantHealer(int health, float timeDuration) {
        _health = health;
    }

    public int Health => _health;
    public float TimeDuration => _timeDuration;
}