using System;
using UnityEngine;

public class InputSystem : MonoBehaviour {
    public event Action<Vector3> Clicked;
    private Vector3 _position;

    void Update() {
        if (Input.GetMouseButton(0)) {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
 