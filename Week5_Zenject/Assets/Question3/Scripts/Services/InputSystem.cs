using System;
using UnityEngine;
using Zenject;

namespace Question3 {
    public class InputSystem : ITickable {
        public const int LeftMouseButton = 0;
        public event Action<Vector3> Clicked;

        public void Tick() {
            if (Input.GetMouseButtonDown(LeftMouseButton)) {
                Clicked?.Invoke(Input.mousePosition);
            }
        }
    }
}