using UnityEngine;

public class Worker : MonoBehaviour, IMovable {
    [SerializeField] private WorkerConfig _config;
    [SerializeField] private WorkerView _view;

    private WorkerStateMachine _stateMachine;

    [field: SerializeField] public float Speed { get; private set; }
    public WorkerConfig Config => _config;
    public WorkerView View => _view;
    public WorkerStateMachine StateMachine => _stateMachine;
    public Transform Transform { get; private set; }
        

    private void Start() {
        Transform = transform;

        _stateMachine = new WorkerStateMachine(this);
         _view.Initialize(_stateMachine);
    }

    private void Update() {
        _stateMachine.Update();
    }
}
