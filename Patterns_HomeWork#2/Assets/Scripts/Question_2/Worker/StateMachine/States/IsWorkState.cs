using UnityEngine;

public class IsWorkState : IState {
    private WorkerStateMachine _stateMachine;
    private Worker _worker;
    private float _workTime;

    private float _time;

    public IsWorkState(WorkerStateMachine workerStateMachine, Worker worker) {
        _stateMachine = workerStateMachine;
        _worker = worker;
        _workTime = _worker.Config.IsWorkStateConfig.Time;
    }

    public void Enter() => _worker.View.StartIsWork();
    
    public void Update() {
        _time += Time.deltaTime;

        if (_time >= _workTime) 
        {
            _time = 0;
            _stateMachine.SwitchState<FromWorkState>();
        }
    }

    public void Exit() => _worker.View.StopIsWork();

    public void HandleInput() { }
}
