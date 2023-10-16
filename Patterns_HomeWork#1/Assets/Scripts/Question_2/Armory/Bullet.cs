using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    [Tooltip("—корость")]
    [SerializeField] private float _speed = 10f;
    [Tooltip("”рон")]
    [SerializeField] private int _damage = 10;
    [Tooltip("¬рем€ жизни")]
    [SerializeField] private float _lifeTime = 5f;
    [Tooltip("Ёффект попадани€")]
    protected GameObject _hitParticle;

    private Rigidbody _rigidbody;

    public void Init(Vector3 velocity) {
        _rigidbody ??= GetComponent<Rigidbody>();
        _rigidbody.velocity = velocity * _speed;
        StartCoroutine(DelayDestroy());
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody == null) {
            Destroy();
            return;
        }

        if (collision.rigidbody.gameObject.TryGetComponent(out EnemyCharacter enemyCharacter)) {
            int damage = 0;
            if (collision.collider.gameObject.CompareTag("Body")) {
                damage = _damage;
            } else if (collision.collider.gameObject.CompareTag("Head")) {
                damage = _damage * 2;
            }
            enemyCharacter.ApplyDamage(damage); 
        }

        Destroy();
    }

    private IEnumerator DelayDestroy() {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Destroy();
    }

    private void Destroy() {
        Destroy(gameObject);
    }
}
