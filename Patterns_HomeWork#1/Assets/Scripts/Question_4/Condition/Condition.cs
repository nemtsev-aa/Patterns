
using System;

public class Condition {
    public event Action Complited;

    public void SetComplited() {
        Complited?.Invoke();
    }
}
