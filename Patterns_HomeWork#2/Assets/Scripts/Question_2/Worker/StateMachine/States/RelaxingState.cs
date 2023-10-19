using UnityEngine;

public class RelaxingState : IState {
    private IStateSwitcher _stateSwitcher;
    private Worker _worker;
    private float _relaxingTime;

    private float _time;

    public RelaxingState(IStateSwitcher stateSwitcher, Worker worker) {
        _stateSwitcher = stateSwitcher;
        _worker = worker;
        _relaxingTime = _worker.Config.RelaxingStateConfig.Time;
    }

    public void Enter() { }

    public void Update() {
        _time += Time.deltaTime;
        
        if (_time >= _relaxingTime)
        {
            _time = 0;
            _stateSwitcher.SwitchState<MoveToWorkState>();
        }
    }

    public void Exit() { }

    public void HandleInput() { }
}
