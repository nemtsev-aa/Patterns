using System;

public class UnitRunningProperties {
    private float _slowSpeed;
    private float _speed;
    private float _fastSpeed;
    private float _speedMultiplier;

    public UnitRunningProperties(float slowSpeed, float speed, float fastSpeed, float speedMultiplier) {
        _slowSpeed = slowSpeed;
        _speed = speed;
        _fastSpeed = fastSpeed;
        _speedMultiplier = speedMultiplier;
    }

    public float SlowSpeed {
        get => _slowSpeed * _speedMultiplier;
        set {

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _slowSpeed = value;
        }
    }

    public float Speed {
        get => _speed * _speedMultiplier;
        set {

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    public float FastSpeed {
        get => _fastSpeed * _speedMultiplier;
        set {

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _fastSpeed = value;
        }
    }

    public float SpeedMultiplier {
        get => _speedMultiplier * _speedMultiplier;
        set {

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speedMultiplier = value;
        }
    }
}

