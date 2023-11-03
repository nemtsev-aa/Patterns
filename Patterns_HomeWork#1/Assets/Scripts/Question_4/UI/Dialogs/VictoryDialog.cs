using UnityEngine;
using UnityEngine.UI;

public class VictoryDialog : Dialog {
    [SerializeField] private Button _backToMainMenuButton;

    private void Start() => _backToMainMenuButton.onClick.AddListener(BackToMainMenuButtonClick);
 
    private void BackToMainMenuButtonClick() => Close();

    public override void Dispose() => _backToMainMenuButton.onClick.RemoveListener(BackToMainMenuButtonClick);
}
