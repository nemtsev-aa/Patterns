using UnityEngine;

public class Worker : MonoBehaviour {
    [SerializeField] private WorkerConfig _config;
    [SerializeField] private WorkerView _view;

    private WorkerStateMachine _stateMachine;

    public WorkerConfig Config => _config;
    public WorkerView View => _view;
    public WorkerStateMachine StateMachine => _stateMachine;

    private void Awake() {
        _view.Initialize();
        _stateMachine = new WorkerStateMachine(this);
    }

    private void Update() {
        _stateMachine.Update();
    }
}
