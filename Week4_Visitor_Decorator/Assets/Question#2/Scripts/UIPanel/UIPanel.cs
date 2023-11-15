using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour {
    public event Action<UIPanel> Closed;
    
    [SerializeField] protected Button SwitchButton;
    [SerializeField] protected Image CoinIcon;
    [SerializeField] protected Image EnergyIcon;

    public virtual void Show() => gameObject.SetActive(true);

    public virtual void Hide() => gameObject.SetActive(false);

    public virtual void UpdateIcons(Sprite coin, Sprite energy) {
        CoinIcon.sprite = coin;
        EnergyIcon.sprite = energy;
    }

    private void OnEnable() {
        SwitchButton.onClick.AddListener(OnSwitchClick);
    }

    private void OnDisable() {
        SwitchButton.onClick.RemoveListener(OnSwitchClick);
    }

    private void OnSwitchClick() => Closed?.Invoke(this);
}
