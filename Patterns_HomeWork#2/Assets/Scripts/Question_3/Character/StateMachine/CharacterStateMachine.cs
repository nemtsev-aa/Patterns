using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher {
    private List<IState> _states;
    private IState _currentState;
    private StateMachineData _data;

    public StateMachineData Data => _data;

    public CharacterStateMachine(Character character) {
        _data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdlingState(this, _data, character),
            new RunningState(this, _data, character),
            new JumpingState(this, _data, character),
            new FallingState(this, _data, character),
            new WalkingState(this, _data, character),
            new FastRunningState(this, _data, character),
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

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
