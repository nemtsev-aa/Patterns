using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private MoveEffector _moveEffectManager;
    
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;
    
    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;
    public MoveEffector MoveEffector => _moveEffectManager;
    public CharacterStateMachine StateMachine =>_stateMachine;

    private void Awake()
    {
        _view.Initialize();
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
        _moveEffectManager.Init(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
