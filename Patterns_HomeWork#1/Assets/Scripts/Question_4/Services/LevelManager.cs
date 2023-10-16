using UnityEngine;

public class LevelManager : MonoBehaviour, IService {
    public SphereCraetor SphereCraetor => _sphereCraetor;

    [SerializeField] private SphereCraetor _sphereCraetor;
    [SerializeField] private SphereCounter _sphereCounter;
    [SerializeField] private InputSystem _inputSystem;

    private VictoryCondition _victory;

    public void Init(VictoryCondition victory) {
        _victory = victory;

        _victory.Complited += Restart;

        _sphereCraetor.Init(_victory);
        _sphereCounter.Init(_victory, _sphereCraetor.Spheres, _inputSystem);
    }

    public void Restart() {
        _victory = null;
        _sphereCraetor.Restart();
        _sphereCounter.Restart();
    }
}
