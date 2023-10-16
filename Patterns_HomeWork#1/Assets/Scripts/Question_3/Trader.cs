using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trader : MonoBehaviour {
    private const float ColliderRadius = 1.2f;

    [SerializeField] private List<ParticleSystem> _particles = new List<ParticleSystem>();
    
    private int[] _limitValues;
    private ParticleSystem _particle;
    private Dictionary<Func<int, bool>, Action> _tradingStrategies;
    private ITrader _traderStrategie;
    private PlayerCharacter _player;

    public void Init(int[] limitValues) {
        _limitValues = limitValues;

        CreateStrategies();
    }

    private void CreateStrategies() {
        _tradingStrategies = new Dictionary<Func<int, bool>, Action> {
            { x => x < _limitValues[0] , () =>  _traderStrategie = new NotTrade(_particles[0])},
            { x => x < _limitValues[1] , () =>  _traderStrategie = new FruitTrade(_particles[1])},
            { x => x < _limitValues[2] , () =>  _traderStrategie = new ArmorTrade(_particles[2])},
        };
    }

    private void OnCollisionEnter(Collision collision) {
        if (_player != null) return;

        if (collision.rigidbody.TryGetComponent(out PlayerCharacter player)) {
            _player = player;
            transform.LookAt(_player.transform);

            SetStrategie();
            ShowParticle();
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.rigidbody.TryGetComponent(out PlayerCharacter player)) {
            _player = null;
            Destroy(_particle.gameObject);
            _particle = null;
        }
    }
    
    private void SetStrategie() {
        _tradingStrategies.First(ts => ts.Key(_player.Reputation)).Value();
    }

    private void ShowParticle() {
        if (_particle != null) return;

        _particle = Instantiate(_traderStrategie.ParticleSystem, transform.position, Quaternion.Euler(-90, 0, 0));
        _particle.Play();
    }

    #region UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + Vector3.up, ColliderRadius);
    }
    #endregion
}
