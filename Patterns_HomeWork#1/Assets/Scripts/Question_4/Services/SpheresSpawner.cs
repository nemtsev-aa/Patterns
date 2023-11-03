using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpheresSpawner : MonoBehaviour, IService {
    private const int Zoom = -100;

    [SerializeField] private float _spawnCooldown = 0.5f;
    [SerializeField] private SphereFactory _factory;

    private List<Sphere> _spheres;
    private Coroutine _spawn;
    private IEnumerable<Vector3> _positions;

    public IEnumerable<Sphere> Spheres => _spheres;
    public IEnumerable<Sphere> SpheresPrefabs => _factory.SpheresPrefabs;

    public event Action SpheresSpawned;

    public void Init(IEnumerable<Vector3> positions) {
        _positions = positions;
        SetCameraPosition();
        StartWork();
    }
    
    public void StartWork() {
        StopWork();

        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork() {
        if (_spawn != null)
            StopCoroutine(_spawn);
    }

    public void Restart() {
        _positions = null;
        ClearSphereList();
    }

    private void ClearSphereList() {
        foreach (var iSphere in _spheres) {
            Destroy(iSphere.gameObject);
        }

        _spheres.Clear();
    }

    private IEnumerator Spawn() {
        _spheres = new List<Sphere>();
        for (int i = 0; i < _positions.Count(); i++) {
            Sphere newSphere = _factory.Get(GetRandomColor());
            newSphere.transform.parent = transform;
            newSphere.MoveTo(_positions.ElementAt(i));
            newSphere.OnSphereClicked += RemoveSphere;
    
            _spheres.Add(newSphere);
            
            yield return new WaitForSeconds(_spawnCooldown);
        }

        SpheresSpawned?.Invoke();
    }

    private Color GetRandomColor() {
        int randomIndex = UnityEngine.Random.Range(0, SpheresPrefabs.Count());
        return SpheresPrefabs.ElementAt(randomIndex).Color;
    }

    private void RemoveSphere(Sphere sphere) {
        sphere.OnSphereClicked -= RemoveSphere;
        _spheres.Remove(sphere);
    }
    
    private void SetCameraPosition() {
        Vector3 startPoint = _positions.ElementAt(0);
        Vector3 endPoint = _positions.ElementAt(_positions.Count() - 1);

        Camera.main.transform.position = (startPoint + endPoint) / 2;
        Camera.main.transform.position += Vector3.forward * (Zoom);
    }
}
