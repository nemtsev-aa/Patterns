using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WorkerView : MonoBehaviour {
    private const string ToWork = "ToWork";
    private const string IsWork = "IsWork";
    private const string FromWork = "FromWork";
    private const string IsRelax = "IsRelax";

    private Animator _animator;
 
    private Dictionary<IState, string> _states;
    private IState _currentState;

    public void Initialize(WorkerStateMachine stateMachine) {
        _animator ??= GetComponent<Animator>();
        
        stateMachine.OnStateChanged += SwitchView;
        
        IReadOnlyList<IState> states = stateMachine.States;
        CreateStatesDictionary(states);
    }

    public void SwitchView(IState state) {
        if (_currentState != null)
            ShowView(_currentState, false);

        _currentState = state;
        ShowView(_currentState, true);
    }

    private void CreateStatesDictionary(IReadOnlyList<IState> states) {
        _states = new Dictionary<IState, string> {
            {FindStateByType<MoveToWorkState>(states), ToWork },
            {FindStateByType<WorkingState>(states), IsWork },
            {FindStateByType<MoveToRelaxState>(states), FromWork },
            {FindStateByType<RelaxingState>(states), IsRelax }
        };
    }  

    private IState FindStateByType<T>(IReadOnlyList<IState> states) {
        return states.FirstOrDefault(state => state is T);
    }

    private void ShowView(IState state, bool status) {
        if (_states.TryGetValue(state, out string value)) 
            _animator.SetBool(value, status);
        else 
            Debug.LogError($"State {state} the key for switching animations is not assigned");
    }

}
