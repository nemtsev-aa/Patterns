using UnityEngine;

public class WorkingState : IState {
    private IStateSwitcher _stateSwitcher;
    private Worker _worker;
    private float _workTime;
    private float _time;

    public WorkingState(IStateSwitcher stateSwitcher, Worker worker) {
        _stateSwitcher = stateSwitcher;
        _worker = worker;
         _workTime = _worker.Config.IsWorkStateConfig.Time;
    }

    public void Enter() { }
    
    public void Update() {
        _time += Time.deltaTime;

        if (_time >= _workTime) 
        {
            _time = 0;
            _stateSwitcher.SwitchState<MoveToRelaxState>();
        }
    }

    public void Exit() { }

    public void HandleInput() { }
}
