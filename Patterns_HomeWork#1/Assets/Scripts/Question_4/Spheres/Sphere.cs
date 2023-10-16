using System;
using UnityEngine;

public class Sphere : MonoBehaviour {
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    [SerializeField] private ParticleSystem _destroyParticle;

    public event Action<Sphere> OnSphereClicked;

    public void Click() {
        OnSphereClicked?.Invoke(this);

        Instantiate(_destroyParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void OnMouseEnter() {
        transform.localScale = Vector3.one * 1.2f;
    }

    public void OnMouseExit() {
        transform.localScale = Vector3.one;
    }
}
