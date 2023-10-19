using UnityEngine;

public abstract class MoveToPointState : IState {
    private const float MinDistanceToTarget = 0.05f;

    protected IStateSwitcher StateSwitcher;
    private readonly Transform _targetTransform;
    private readonly Transform _moverTransform;
    private readonly float _speed;
    private bool _isMoving;

    public MoveToPointState(IStateSwitcher stateSwitcher, Transform targetTransform, IMovable mover) {
        StateSwitcher = stateSwitcher;
        _targetTransform = targetTransform;
        _moverTransform = mover.Transform;
        _speed = mover.Speed;
    }

    public void Enter() {
        _isMoving = true;
        _moverTransform.LookAt(_targetTransform.position, Vector3.up);
    }

    public void Update() {
        if (_isMoving == false)
            return;

        MoveToTargetPosition();

        if (TryReachTarget()) 
            OnReachTarget();
    }

    public void Exit() {
        _isMoving = false;
    }

    public void HandleInput() { }
    
    protected abstract void OnReachTarget();

    private void MoveToTargetPosition() {
        _moverTransform.transform.position = Vector3.MoveTowards(_moverTransform.position, _targetTransform.position, _speed * Time.deltaTime);
    }

    private bool TryReachTarget() {
        Vector3 direction = _targetTransform.position - _moverTransform.position;
        if (direction.magnitude > MinDistanceToTarget)
            return false;
     
        _moverTransform.transform.rotation = Quaternion.Lerp(_moverTransform.rotation, _targetTransform.rotation, _speed * Time.deltaTime);
        return true;
    }
}