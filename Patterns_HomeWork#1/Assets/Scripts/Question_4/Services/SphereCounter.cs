using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereCounter : MonoBehaviour {
    private VictoryCondition _victory;
    private IEnumerable<Sphere> _spheres;
    private InputSystem _inputSystem;

    public void Init(VictoryCondition victory, IEnumerable<Sphere> spheres, InputSystem inputSystem) {
        _victory = victory;
        _spheres = spheres;
        _inputSystem = inputSystem;

        CreateSubscribes();
    }

    public void Restart() {
        _victory = null;
        _spheres = null;
        _inputSystem = null;
    }

    private void CreateSubscribes() {
        _inputSystem.Clicked += ClickRegistration;
        
        foreach (var iSphere in _spheres) {
            iSphere.OnSphereClicked += CountNumberSpheres;
        }

        _victory.Complited += Restart;
    }

    private void ClickRegistration(Vector3 mousePosition) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.TryGetComponent(out Sphere sphere)) {
                sphere.Click();
            }
        }
    }

    private void CountNumberSpheres(Sphere sphere) {
        if (_victory is AllSphereDestroyed) CountNumberAllSpheres(sphere);
        if (_victory is SameColorSphereDestroyed) CountNumberSameColorSpheres(sphere);
    }

    private void CountNumberAllSpheres(Sphere sphere) {
        if (_spheres.Count() == 0) _victory.SetComplited();
    }

    private void CountNumberSameColorSpheres(Sphere sphere) {
        SameColorSphereDestroyed sameColorVictoryType = (SameColorSphereDestroyed)_victory;
        if (sphere.GetType() != sameColorVictoryType.Sphere.GetType()) return;
        if (CountNumberSpheresByType() == 0) _victory.SetComplited();
    }

    private int CountNumberSpheresByType() {
        SameColorSphereDestroyed sameColorVictoryType = (SameColorSphereDestroyed)_victory;
        int count = _spheres.Count(item => item.GetType() == sameColorVictoryType.Sphere.GetType());
        return count;
    }
}
