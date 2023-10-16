using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereCraetor : MonoBehaviour, IService {
    private const string ÎbjName = "Sphere_";
    private const int MinNumberSpheresInDistribution = 2;
    public IEnumerable<Sphere> SpherePrefabs => _spherePrefabs;
    public IEnumerable<Sphere> Spheres => _spheres;

    [SerializeField] private List<Sphere> _spherePrefabs = new List<Sphere>();
    [Header("Settings")]
    [SerializeField, Range(1, 4)] private int _rowCount;
    [SerializeField, Range(1, 4)] private int _columnCount;
    [SerializeField] private Vector3 _startPos = Vector3.zero;
    [SerializeField] private Vector3 _offset = Vector3.zero;

    private List<Sphere> _spheres = new List<Sphere>();
    private VictoryCondition _victory;

    public void Init(VictoryCondition victory) {
        _victory = victory;
        _victory.Complited += Restart;

        CreateDistribution();
        SetCameraPosition();
    }

    public void Restart() {
        _victory = null;
        
        foreach (var iSphere in _spheres) {
            Destroy(iSphere.gameObject);
        }

        _spheres.Clear();
        _startPos = Vector3.zero;
    }

    private void CreateDistribution() {
        if (_victory is AllSphereDestroyed) CreateSpheres();

        if (_victory is SameColorSphereDestroyed) 
            if (CountNumberSpheresByType() <= MinNumberSpheresInDistribution) CreateSpheres();
    }

    private void CreateSpheres() {
        int id = 0;
        float posXreset = _startPos.x;
        for (int y = 0; y < _columnCount; y++) {
            _startPos.y -= _offset.y;
            for (int x = 0; x < _rowCount; x++) {
                id++;
                _startPos.x += _offset.x;
                CreateSphere(id, out Sphere newSphere);
                _spheres.Add(newSphere);
                newSphere.OnSphereClicked += RemoveSphere;
            }
            _startPos.x = posXreset;
        }
    }

    private void SetCameraPosition() {
        Camera.main.transform.position = (_spheres[0].transform.position + _spheres[_spheres.Count-1].transform.position) / 2;
        Camera.main.transform.position += Vector3.forward * (-100);
    }

    private void CreateSphere(int id, out Sphere newSphere) {
        Sphere prefab = GetPrefab();
        Vector3 newSpherePosition = GetPosition();
        newSphere = Instantiate(prefab, newSpherePosition, prefab.transform.rotation);
        newSphere.name = ÎbjName + id;
        newSphere.transform.parent = transform;
    }
    
    private int CountNumberSpheresByType() {
        SameColorSphereDestroyed sameColorVictoryType = (SameColorSphereDestroyed)_victory;
        int count = _spheres.Count(item => item.GetType() == sameColorVictoryType.Sphere.GetType());
        return count;
    }

    private void RemoveSphere(Sphere sphere) {
        _spheres.Remove(sphere);
    }

    private Sphere GetPrefab() {
        int randomInt = UnityEngine.Random.Range(0, _spherePrefabs.Count);
        return _spherePrefabs[randomInt];
    }

    private Vector3 GetPosition() {
        return new Vector2(_startPos.x, _startPos.y);
    }
}
