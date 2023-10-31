using UnityEngine;

public class TraderView : MonoBehaviour {
    private const float ColliderRadius = 1.2f;

    private ParticleSystem _particle;

    public void ShowParticle(ITrader trader) {
        if (_particle != null)
            return;

        _particle = Instantiate(trader.Config.Particle, transform.position, Quaternion.Euler(-90, 0, 0));
        _particle.Play();
    }

    public void HideParticle() {
        if (_particle != null) {
            Destroy(_particle.gameObject);
            _particle = null;
        }
    }

    #region UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + Vector3.up, ColliderRadius);
    }
    #endregion
}
