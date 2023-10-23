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
        
    }

    public void TakeHealing(IHealth heal) {
        
    }

    #endregion

    private void Awake() {
        _view.Initialize();

        _characterController = GetComponent<CharacterController>();

        _input = new PlayerInput();

        var runConfig = Config.RunningStateConfig;
        _runningProperties = new UnitRunningProperties(runConfig.SlowSpeed, runConfig.Speed, runConfig.FastSpeed, runConfig.SpeedMultiplier);
        
        _stateMachine = new CharacterStateMachine(this);

        _effectTaker = new CharacterEffectTaker(_runningProperties, _stateMachine.Data, _view);
        _coinCounter = new CoinCounter(0);

        _health = new Health(_config.GeneralConfig.MaxHealth);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
