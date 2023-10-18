using UnityEngine;

public class ToWorkState : IState {
    private const float MinDistanceToTarget = 0.05f;

    private WorkerStateMachine _stateMachine;
    private Worker _worker;
    private Transform _targetTransform;
    private Transform _workerTransform;
    private float _speed;
    private bool _isMoving;

    public ToWorkState(WorkerStateMachine workerStateMachine, Worker worker) {
        _stateMachine = workerStateMachine;
        _worker = worker;
        _workerTransform = _worker.transform;
        _targetTransform = _worker.Config.ToWorkStateConfig.WorkPoint;
        _speed = _worker.Config.ToWorkStateConfig.Speed;
    }

    public void Enter() {
        StartMove();
        _worker.View.StartToWork();
    }

    public void Update() {
        if (_isMoving == false)
            return;

        float LerpRate = _speed * Time.deltaTime;
        _worker.transform.position = Vector3.MoveTowards(_workerTransform.position, _targetTransform.position, LerpRate);
        _worker.transform.rotation = Quaternion.Lerp(_workerTransform.rotation, _targetTransform.rotation, LerpRate);

        Vector3 direction = _targetTransform.position - _workerTransform.position;
        
        if (direction.magnitude <= MinDistanceToTarget) 
            _stateMachine.SwitchState<IsWorkState>();
    }
    
    public void Exit() {
        StopMove();
        _worker.View.StopToWork();
    }

    public void HandleInput() { }

    private void StartMove() => _isMoving = true;

    private void StopMove() => _isMoving = false;
}
