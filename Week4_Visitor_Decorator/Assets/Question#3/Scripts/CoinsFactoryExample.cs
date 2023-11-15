using UnityEngine;

public class CoinsFactoryExample : MonoBehaviour {
    [SerializeField] private CreateCoinsPanel _createCoinsPanel;
    [SerializeField] private CoinSpawner _spawner;

    private CoinsCreateMediator _mediator;

    private void Awake() {
        _mediator = new CoinsCreateMediator(_createCoinsPanel, _spawner);
    }
}