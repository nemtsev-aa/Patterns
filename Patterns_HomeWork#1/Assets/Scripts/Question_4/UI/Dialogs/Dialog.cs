using System;
using UnityEngine;

public class Dialog : MonoBehaviour {
    public event Action OnClosed;

    public virtual void Show(bool value) {
        gameObject.SetActive(value);
    }

    public virtual void Close() {
        OnClosed?.Invoke();
    }
}
