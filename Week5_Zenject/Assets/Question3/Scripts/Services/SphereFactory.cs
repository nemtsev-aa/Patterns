using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;


namespace Question3 {
    public class SphereFactory {
        private SpherePrefabConfig _config;
        private IEnumerable<Sphere> _spheresPrefabs;
        private DiContainer _container;

        public SphereFactory(SpherePrefabConfig config, DiContainer container) {
            _config = config;
            _spheresPrefabs = _config.Spheres;
            _container = container;
        }

        public Sphere Get(Color sphereColor) {
            return _container.InstantiatePrefabForComponent<Sphere>(GetPrefabByColor(sphereColor));
        }

        private Sphere GetPrefabByColor(Color sphereColor) {
            Sphere prefab = _spheresPrefabs.First(prefab => prefab.Color == sphereColor);

            if (prefab != null)
                return prefab;

            throw new ArgumentException(nameof(sphereColor));
        }
    }
}