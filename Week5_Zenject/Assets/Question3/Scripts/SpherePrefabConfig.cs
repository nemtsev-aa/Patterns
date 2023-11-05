using System.Collections.Generic;
using UnityEngine;

namespace Question3 {
    [CreateAssetMenu(fileName = "SpheresPrefabConfig", menuName = "Configs/Q3_SpherePrefabConfig")]
    public class SpherePrefabConfig : ScriptableObject {
        [SerializeField] private List<Sphere> _spheres;

        public IEnumerable<Sphere> Spheres => _spheres;
    }
}