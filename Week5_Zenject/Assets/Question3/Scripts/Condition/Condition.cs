using System;
using UnityEngine;

namespace Question3 {
    public class Condition {
        public Action Complited;

        public void SetComplited() {
            Debug.Log($"{this}");
            Complited?.Invoke();
        }
    }
}