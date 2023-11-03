using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SphereFactory", menuName = "Factory/SphereFactory")]
public class SphereFactory : ScriptableObject {
    [SerializeField] private List<Sphere> _spheresPrefabs = new List<Sphere>();
    public IEnumerable<Sphere> SpheresPrefabs => _spheresPrefabs;

    public Sphere Get(Color sphereColor) {
        return Instantiate(GetPrefabByColor(sphereColor));
    }

    private Sphere GetPrefabByColor(Color sphereColor) {
        Sphere prefab = _spheresPrefabs.First(prefab => prefab.Color == sphereColor);
        
        if (prefab != null)
            return prefab;

        throw new ArgumentException(nameof(sphereColor));
    }
}