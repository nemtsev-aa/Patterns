using UnityEngine;

public abstract class ActionState : IState {
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly float ActionTime;
    protected float _time;

    public ActionState(IStateSwitcher stateSwitcher, float actionTime) {
        StateSwitcher = stateSwitcher;
        ActionTime = actionTime;
    }

    public void Enter() { }

    public void Update() {
        _time += Time.deltaTime;

        if (_time >= ActionTime) {
            _time = 0;
            OnReachTarget();
        }
    }

    public void Exit() { }

    public void HandleInput() { }

    protected abstract void OnReachTarget();
}