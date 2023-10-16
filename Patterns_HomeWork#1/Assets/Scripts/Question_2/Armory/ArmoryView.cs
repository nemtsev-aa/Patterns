using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArmoryView : MonoBehaviour {
    [Tooltip("���������� ���� - �����")]
    [SerializeField] private TextMeshProUGUI _bulletsCountText;
    [Tooltip("������������� ������ - ������")]
    [SerializeField] private Toggle[] _weaponsIcon;

    public void UpdateBulletsCount(int bulletCount) {
        _bulletsCountText.text = $"{bulletCount}"; 
    }

    public void UpdateSelectionWeaponIcon(int weaponIndex) {
        _weaponsIcon[weaponIndex].isOn = true;
    }
}
