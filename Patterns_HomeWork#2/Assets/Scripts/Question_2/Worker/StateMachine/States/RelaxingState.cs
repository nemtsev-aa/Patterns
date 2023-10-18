using UnityEngine;

public class RelaxingState : IState {
    private WorkerStateMachine _stateMachine;
    private Worker _worker;
    private float _relaxingTime;

    private float _time;

    public RelaxingState(WorkerStateMachine workerStateMachine, Worker worker) {
        _stateMachine = workerStateMachine;
        _worker = worker;
        _relaxingTime = _worker.Config.RelaxingStateConfig.Time;
    }

    public void Enter() => _worker.View.StartIsRelax();

    public void Update() {
        _time += Time.deltaTime;
        
        if (_time >= _relaxingTime)
        {
            _time = 0;
            _stateMachine.SwitchState<ToWorkState>();
        }
    }

    public void Exit()  => _worker.View.StopIsRelax();

    public void HandleInput() { }
}
