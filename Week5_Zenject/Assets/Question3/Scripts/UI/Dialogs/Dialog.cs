using System;
using UnityEngine;

namespace Question3 {
    public class Dialog : MonoBehaviour, IDisposable {
        public event Action OnClosed;

        public virtual void Show(bool value) {
            gameObject.SetActive(value);
        }

        public virtual void Close() {
            OnClosed?.Invoke();
        }

        public virtual void Dispose() {

        }
    }
}