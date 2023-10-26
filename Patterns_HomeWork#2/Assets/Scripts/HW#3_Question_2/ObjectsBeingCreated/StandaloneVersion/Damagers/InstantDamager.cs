public class InstantDamager : IDamage {
    private int _damage;
    private float _timeDuration;

    public InstantDamager(int damage, float timeDuration) { 
        _damage = damage;
        _timeDuration = timeDuration;
    }

    public int Damage => _damage;
    public float TimeDuration => _timeDuration;
}

