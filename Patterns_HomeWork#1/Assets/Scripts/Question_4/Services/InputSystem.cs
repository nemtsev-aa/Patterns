using System;
using UnityEngine;

public class InputSystem : MonoBehaviour {
    public const int LeftMouseButton = 0;
    public event Action<Vector3> Clicked;

    void Update() {
        if (Input.GetMouseButton(LeftMouseButton)) 
            Clicked?.Invoke(Input.mousePosition);
    }
}
 