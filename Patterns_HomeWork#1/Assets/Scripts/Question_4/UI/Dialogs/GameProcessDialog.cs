using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameProcessDialog : Dialog {
    private const string AllColorQuestionText = "Лопни все шарики";
    private const string SameColorQuestionText = "Лопни шарики одного цвета";

    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private TextMeshProUGUI _helpText;
    private string text = "";

    public void SetAllColorVictoryCondition() {
        _helpText.text = AllColorQuestionText;
        _helpText.color = Color.white;
    }

    public void SetSameColorVictoryCondition(Sphere sphere) {
        _helpText.text = SameColorQuestionText;
        _helpText.color = sphere.Color;
    }

    private void Start() => _backToMainMenuButton.onClick.AddListener(BackToMainMenuButtonClick);

    private void BackToMainMenuButtonClick() => Close();

    public override void Dispose() => _backToMainMenuButton.onClick.RemoveListener(BackToMainMenuButtonClick);
}
