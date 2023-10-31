using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    private Rigidbody _rigidbody;
    private BulletConfig _config;

    public void Init(BulletConfig config) {
        _config = config;

        _rigidbody ??= GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity) {
        _rigidbody.velocity = velocity * _config.Speed;
        Invoke(nameof(Destroy), _config.LifeTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody == null) {
            Destroy();
            return;
        }

        if (collision.rigidbody.gameObject.TryGetComponent(out EnemyCharacter enemyCharacter)) {
            int damage = 0;
            
            if (collision.collider.gameObject.CompareTag("Body"))
                damage = _config.Damage;
            else if (collision.collider.gameObject.CompareTag("Head"))
                damage = _config.Damage * 2;
           
            enemyCharacter.ApplyDamage(damage); 
        }

        Destroy();
    }

    private void Destroy() => Destroy(gameObject);
}
