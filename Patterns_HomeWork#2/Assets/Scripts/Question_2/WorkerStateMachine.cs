using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkerStateMachine : IStateSwitcher {
    private List<IState> _states;
    private IState _currentState;
    
    public WorkerStateMachine(Worker worker) {
        Transform workPoint = worker.Config.ToWorkStateConfig.WorkPoint;
        Transform relaxingPoint = worker.Config.FromWorkStateConfig.RelaxingPoint;

        _states = new List<IState>()
        {
            new MoveToWorkState(this, workPoint, worker),
            new WorkingState(this, worker),
            new MoveToRelaxState(this, relaxingPoint, worker),
            new RelaxingState(this,  worker)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public IReadOnlyList<IState> States => _states;

    public event Action<IState> OnStateChanged;

    public void SwitchState<T>() where T : IState {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();

        OnStateChanged?.Invoke(_currentState);
    }

    public void Update() => _currentState.Update();
}
