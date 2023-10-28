using UnityEngine;
using UnityEngine.UI;

public class CreateCoinsPanel : MonoBehaviour {
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _destroyButton;

    private CoinsCreateMediator _mediator;

    public void Init(CoinsCreateMediator mediator) {
        _mediator = mediator;
        _destroyButton.gameObject.SetActive(false);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnCreateClick() {
        _createButton.gameObject.SetActive(false);
        _destroyButton.gameObject.SetActive(true);
        _mediator.CreateCoins();
    }

    private void OnDestroyClick() {
        _createButton.gameObject.SetActive(true);
        _destroyButton.gameObject.SetActive(false);
        _mediator.DestroyCoins();
    }

    private void OnEnable() {
        _createButton.onClick.AddListener(OnCreateClick);
        _destroyButton.onClick.AddListener(OnDestroyClick);
    }

    private void OnDisable() {
        _createButton.onClick.RemoveListener(OnCreateClick);
        _destroyButton.onClick.RemoveListener(OnDestroyClick);
    }
}
