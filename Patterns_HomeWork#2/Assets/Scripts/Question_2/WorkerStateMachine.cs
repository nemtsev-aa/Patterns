using System.Collections.Generic;
using System.Linq;

public class WorkerStateMachine : IStateSwitcher {
    private List<IState> _states;
    private IState _currentState;

    public WorkerStateMachine(Worker worker) {

        _states = new List<IState>()
        {
            new ToWorkState(this, worker),
            new IsWorkState(this, worker),
            new FromWorkState(this, worker),
            new RelaxingState(this,  worker)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
