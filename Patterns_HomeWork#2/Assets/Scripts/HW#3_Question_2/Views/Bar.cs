using UnityEngine;

public class Bar : MonoBehaviour {
    [SerializeField] private RectTransform _filledImage;

    private float _defaultWidth;

    private void OnValidate() {
        _defaultWidth = _filledImage.sizeDelta.x;
    }

    public void Display(float currentExperience, float nextLevelExperience) {
        float percent = currentExperience / nextLevelExperience;
        _filledImage.sizeDelta = new Vector2(_defaultWidth * percent, _filledImage.sizeDelta.y);
    }
}