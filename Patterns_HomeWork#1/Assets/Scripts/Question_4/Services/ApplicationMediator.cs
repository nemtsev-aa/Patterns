using System;
using UnityEngine;

public class ApplicationMediator : MonoBehaviour {
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private DialogSwitcher _dialogSwitcher;
    [SerializeField] private SpheresSpawner _spawner;
    [SerializeField] private SpheresPlacer _placer;
    [SerializeField] private int _sphereCount = 16;
    
    private DialogSubscriber _dialogSubscriber;
    private Level _level;
    private VictoryCondition _victory;
    private VictoryConditionTypes _conditionType;
    private Color _selectedColor;
    

    public SpheresSpawner SpheresSpawner => _spawner;

    private void Start() {
        Init();
    }

    private void Init() {
        _dialogSwitcher.Init();
        _dialogSubscriber = new DialogSubscriber(this, _dialogSwitcher);

        ShowStartMenu();
    }

    public void SetAllColorVictoryConditionType() {
        _conditionType = VictoryConditionTypes.AllColor;
        _selectedColor = Color.clear;

        PrepareLevel();
    }

    public void SetSameColorVictoryConditionType(Sphere sphere) {
        _conditionType = VictoryConditionTypes.SameColor;
        _selectedColor = sphere.Color;

        PrepareLevel();
    }

    public void ApplicationRestert() {
        ShowStartMenu();
    }

    public void ApplicationQuit() => Application.Quit();

    private void ShowStartMenu() => _dialogSwitcher.ShowDialog<StartMenuDialog>();
    
    private void PrepareLevel() {
        _dialogSwitcher.ShowDialog<GameProcessDialog>();

        _level = new Level(_spawner, _placer, _sphereCount);
        _level.Prepared += StartLevel;
    }

    private void StartLevel() {
        SetVictoryCondition();
    }

    private void SetVictoryCondition() {
        if (_conditionType == VictoryConditionTypes.None) {
            return;
        }

        VictoryConditionFactory conditionFactory = new VictoryConditionFactory(_inputSystem, _spawner);
        _victory = conditionFactory.GetVictoryCondition(_conditionType);
        _victory.SetColorDestroyedSpheres(_selectedColor);
        
        _victory.Complited += LevelComplited;
    }

    private void LevelComplited() {
        _victory = null;
        _conditionType = VictoryConditionTypes.None;
        _selectedColor = Color.clear;

         _level.Restart();
        _dialogSwitcher.ShowDialog<VictoryDialog>();
    } 
}
