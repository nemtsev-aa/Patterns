using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IPause {
    private int _health;
    private float _speed;

    private IEnemyTarget _target;
    private bool _isPaused;

    public event Action<Enemy> Destroyed;

    [Inject]
    private void Construct(IEnemyTarget target, PauseHandler pauseHandler) {
        _target = target;
        pauseHandler.Add(this);
    }

    public virtual void Initialize(int helath, float speed) {
        _health = helath;
        _speed = speed;
    }

    public void MoveTo(Vector3 position) => transform.position = position;

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    private void Update() {
        if (_isPaused)
            return;

        Vector3 direction = (_target.Position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IEnemyTarget target)) {
            target.TakeDamage(_health);
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
