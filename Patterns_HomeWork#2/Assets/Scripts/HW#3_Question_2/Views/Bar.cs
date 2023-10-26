using UnityEngine;

public class Bar : MonoBehaviour {
    [SerializeField] private RectTransform _filledImage;
    private float _defaultWidth;

    public void Init() {
        _defaultWidth = _filledImage.sizeDelta.x;
    }

    public void Display(int currentExperience, int nextLevelExperience) {
        float percent = (float)currentExperience / nextLevelExperience;
        _filledImage.sizeDelta = new Vector2(_defaultWidth * percent, _filledImage.sizeDelta.y);
    }

    private void OnValidate() {
        Init();
    }
}