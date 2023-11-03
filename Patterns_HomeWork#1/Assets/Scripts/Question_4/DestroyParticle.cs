using UnityEngine;

public class DestroyParticle : MonoBehaviour {
    [SerializeField] private ParticleSystem _destroyParticle;
    private ParticleSystemRenderer _destroyParticlesRenderer;

    public void Show() {
        _destroyParticlesRenderer = _destroyParticle.GetComponent<ParticleSystemRenderer>();
        Color color = gameObject.GetComponent<Sphere>().Color;
        _destroyParticlesRenderer.sharedMaterial.color = color;
        
        Instantiate(_destroyParticle, transform.position, transform.rotation);
    }
}
