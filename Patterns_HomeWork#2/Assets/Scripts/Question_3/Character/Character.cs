using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IMoveEffectTaker, ICoinPicker, IDamageable {
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private CharacterEffectTaker _effectTaker;
    [SerializeField] private UnitRunningProperties _runningProperties;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;
    private CoinCounter _coinCounter;
    private Health _health;
    private ExperienceCounter _experienceCounter;
    private List<IService> _services;

    #region PublicProperties
    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;
    public CharacterStateMachine StateMachine => _stateMachine;
    public CharacterEffectTaker EffectTaker => _effectTaker;
    public UnitRunningProperties RunningProperties => _runningProperties;
    public CoinCounter CoinCounter => _coinCounter;
    public Health Health => _health;
    public ExperienceCounter ExperienceCounter => _experienceCounter;

    #endregion

    #region MoveEffectTaker

    public void TakeEffect(IMoveEffect moveEffect) {
        _effectTaker.TakeEffect(moveEffect);
        Invoke(nameof(RemoveEffect), moveEffect.TimeDuration);
    }

    public void RemoveEffect() {
        _effectTaker.RemoveEffect();
    }

    #endregion

    #region CoinPicker

    public void PickCoin(int value) {
        _coinCounter.Add(value);
    }

    #endregion

    #region Damage/HealingTaker

    public void TakeDamage(IDamage damage) {
        _health.TakeDamage(damage.Damage);
    }

    public void TakeHealing(IHealth heal) {
        _health.TakeHealing(heal.Health);
    }

    #endregion

    public void Init() {
        _view.Initialize();

        _characterController = GetComponent<CharacterController>();

        _input = new PlayerInput();

        var runConfig = Config.RunningStateConfig;
        _runningProperties = new UnitRunningProperties(runConfig.SlowSpeed, runConfig.Speed, runConfig.FastSpeed, runConfig.SpeedMultiplier);
        
        _stateMachine = new CharacterStateMachine(this);

        _effectTaker = new CharacterEffectTaker(_runningProperties, _stateMachine.Data, _view);
        _coinCounter = new CoinCounter(0);

        var generalConfig = _config.GeneralConfig;
        _health = new Health(generalConfig.MaxHealth);
        _experienceCounter = new ExperienceCounter(generalConfig.ExperienceCurve, generalConfig.MaxLevel, _coinCounter);

        RegistrationServices();
    }

    private void RegistrationServices() {
        _services = new List<IService>() {
            _coinCounter,
            _health,
            _experienceCounter
        };
    }

    public void Reset() {
        _characterController.enabled = false;
        transform.position = Vector3.zero;
        _characterController.enabled = true;

        ResetServices();
    }

    private void ResetServices() {
        foreach (var iService in _services) {
            iService.Reset();
        }
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
