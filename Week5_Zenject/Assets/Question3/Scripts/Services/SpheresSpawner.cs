using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;

namespace Question3 {
    public class SpheresSpawner : MonoBehaviour, IService {
        private const int Zoom = -100;

        private float _spawnCooldown = 0.1f;
        private SpherePrefabConfig _config;
        private SphereFactory _factory;
        private IEnumerable<Vector3> _positions;

        private List<Sphere> _spheres;
        private Coroutine _spawn;
        
        [Inject]
        public void Construct(SpherePrefabConfig config, SphereFactory factory) {
            _config = config;
            _factory = factory;
            Debug.Log($"SpheresSpawner created");
        }

        public IEnumerable<Sphere> Spheres => _spheres;

        public float SpawnCooldown {
            get { return _spawnCooldown; }
            set {
                if (value < 0 ) 
                    throw new ArgumentNullException($"Invalid SpawnCooldown value {value}");

                _spawnCooldown = value;
            }

        }

        public IEnumerable<Vector3> SpawnPositions {
            get { return _positions; }
            set {
                if (value.Count() == 0) 
                    throw new ArgumentNullException($"Invalid SpawnPositions count {value}");

                _positions = value;
            }
        }

        public event Action SpheresSpawned;

        public void StartWork() {
            StopWork();
            SetCameraPosition();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork() {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void Restart() => ClearSphereList();

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
                newSphere.name = $"{Time.time}";
                newSphere.transform.parent = transform;
                newSphere.MoveTo(_positions.ElementAt(i));
                newSphere.OnSphereClicked += RemoveSphere;

                _spheres.Add(newSphere);

                yield return new WaitForSeconds(_spawnCooldown);
            }

            SpheresSpawned?.Invoke();
        }

        private Color GetRandomColor() {
            int randomIndex = UnityEngine.Random.Range(0, _config.Spheres.Count());
            return _config.Spheres.ElementAt(randomIndex).Color;
        }

        private void RemoveSphere(Sphere sphere) {
            sphere.OnSphereClicked -= RemoveSphere;
            _spheres.Remove(sphere);
        }

        private void SetCameraPosition() {
            Vector3 startPoint = _positions.ElementAt(0);
            Vector3 endPoint = _positions.ElementAt(_positions.Count() - 1);

            Camera.main.transform.position = (startPoint + endPoint) / 2;
            Camera.main.transform.position += Vector3.forward * Zoom;
        }
    }
}