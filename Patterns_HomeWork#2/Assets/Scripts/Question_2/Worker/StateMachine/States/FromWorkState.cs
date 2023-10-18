using UnityEngine;

public class FromWorkState : IState {
    private const float MinDistanceToTarget = 0.05f;

    private WorkerStateMachine _stateMachine;
    private Worker _worker;
    private bool _isMoving;
    private Transform _target;
    private Transform _workerTransform;
    private float _speed;

    public FromWorkState(WorkerStateMachine workerStateMachine, Worker worker) {
        _stateMachine = workerStateMachine;
        _worker = worker;
        _target = _worker.Config.FromWorkStateConfig.RelaxingPoint;
        _speed = _worker.Config.FromWorkStateConfig.Speed;
    }

    public void Enter() {
        StartMove();
        _worker.View.StartFromWork();
    }

    public void Update() {
        if (_isMoving == false)
            return;

        float LerpRate = _speed * Time.deltaTime;
        _worker.transform.position = Vector3.MoveTowards(_workerTransform.position, _target.position, LerpRate);
        _worker.transform.rotation = Quaternion.Lerp(_workerTransform.rotation, _target.rotation, LerpRate);

        Vector3 direction = _target.position - _workerTransform.position;
        
        if (direction.magnitude <= MinDistanceToTarget)
           _stateMachine.SwitchState<RelaxingState>();
    }

    public void Exit() {
        StopMove();
        _worker.View.StopFromWork();
    }

    private void StartMove() => _isMoving = true;

    private void StopMove() => _isMoving = false;

    public void HandleInput() { }
}
