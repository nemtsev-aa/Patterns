using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IMoveEffectTaker {

    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private CharacterEffectTaker _effectTaker;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;
    
    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;
    public CharacterStateMachine StateMachine =>_stateMachine;
    public CharacterEffectTaker EffectTaker => _effectTaker;

    public void TakeEffect(IMoveEffect moveEffect) {
        _effectTaker.TakeEffect(moveEffect);
        Invoke(nameof(RemoveEffect), moveEffect.TimeDuration);
    }

    public void RemoveEffect() {
        _effectTaker.RemoveEffect();
    }

    private void Awake()
    {
        _view.Initialize();
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
        _effectTaker = new (_config, _stateMachine.Data, _view);
    }
     
    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
