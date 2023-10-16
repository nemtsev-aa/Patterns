using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameProcessDialog : Dialog {
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private TextMeshProUGUI _helpText;

    public void SetVictoryCondition(VictoryCondition victory) {
        string text = "";

        if (victory is AllSphereDestroyed) text = $"Лопни все шарики";
        if (victory is SameColorSphereDestroyed) {
            text = $"Лопни шарики одного цвета";
            _helpText.color = GetSelectColor((SameColorSphereDestroyed)victory);
        }

        _helpText.text = text;
    }

    private void Start() {
        _backToMainMenuButton.onClick.AddListener(BackToMainMenuButtonClick);
    }

    private Color GetSelectColor(SameColorSphereDestroyed sameColor) {
        return sameColor.Sphere.MeshRenderer.sharedMaterial.color;
    }

    private void BackToMainMenuButtonClick() {
        Close();
    }
}
