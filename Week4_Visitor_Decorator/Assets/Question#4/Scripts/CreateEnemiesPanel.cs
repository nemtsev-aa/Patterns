using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemiesPanel : MonoBehaviour {
    public event Action RandomEnemyKilled;
    
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _destroyButton;
    [SerializeField] private Slider _maxWeightScroll;
    [SerializeField] private TextMeshProUGUI _maxWeightText;
    [SerializeField] private TextMeshProUGUI _currentWeightText;

    private EnemiesCreateMediator _mediator;
    private int _maxWeight;

    public void Init(EnemiesCreateMediator mediator, int maxWeightLimit) {
        _mediator = mediator;
        
        PreparationPanel(maxWeightLimit); 
    }

    public void Show() => ActivateButtons(true);

    public void Hide() => ActivateButtons(false);
 
    public void UpdateWeightText(int value) => _currentWeightText.text = $"{value}";

    private void PreparationPanel(int maxWeightLimit) {
        _destroyButton.gameObject.SetActive(false);
        _maxWeightScroll.maxValue = maxWeightLimit;
        _maxWeightText.text = $"{_maxWeightScroll.minValue}";

        UpdateWeightText(0);
    }
    
    private void Update() {
        if (Input.GetKeyUp(KeyCode.Space))
            RandomEnemyKilled?.Invoke();
    }

    private void ActivateButtons(bool status) {
        _createButton.interactable = status;
        _destroyButton.interactable = status;
    }

    private void OnCreateClick() {
        _createButton.gameObject.SetActive(false);
        _destroyButton.gameObject.SetActive(true);

        _mediator.CreateEnemies(_maxWeight);
    }

    private void OnDestroyClick() {
        _createButton.gameObject.SetActive(true);
        _destroyButton.gameObject.SetActive(false);
        _mediator.DestroyEnemies();
    }

    private void OnEnable() {
        _createButton.onClick.AddListener(OnCreateClick);
        _destroyButton.onClick.AddListener(OnDestroyClick);
        _maxWeightScroll.onValueChanged.AddListener(MaxWeightChanged);
    }

    private void MaxWeightChanged(float value) {
        _maxWeight = (int)value;
        _maxWeightText.text = $"{_maxWeight}";
    }

    private void OnDisable() {
        _createButton.onClick.RemoveListener(OnCreateClick);
        _destroyButton.onClick.RemoveListener(OnDestroyClick);
        _maxWeightScroll.onValueChanged.RemoveListener(MaxWeightChanged);
    }
}
