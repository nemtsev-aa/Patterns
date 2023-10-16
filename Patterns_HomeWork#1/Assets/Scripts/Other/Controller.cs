using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour {
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const int ShootButtonIndex = 0;
    private const string H = "Horizontal";
    private const string V = "Vertical";
    private const string MouseScrollWheel = "Mouse ScrollWheel";

    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private Armory _armory;
    [SerializeField] private float _mouseSensetivity = 2f;

    private bool _hideCursor;

    private void Start() {
        _hideCursor = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEngine.Cursor.lockState = _hideCursor ? CursorLockMode.Locked : CursorLockMode.None;
        }

        float mouseX = 0f;
        float mouseY = 0f;
        bool isShoot = false;

        if (_hideCursor) {
            mouseX = Input.GetAxis(MouseX);
            mouseY = Input.GetAxis(MouseY);
            isShoot = Input.GetMouseButton(ShootButtonIndex);
        }

        float h = Input.GetAxis(H);
        float v = Input.GetAxis(V);
        float rotateX = -mouseY * _mouseSensetivity;
        float rotateY = mouseX * _mouseSensetivity;

        _player.SetInput(h, v, rotateX, rotateY);


        if (isShoot) _armory.TryShoot();

        if (Input.GetAxis(MouseScrollWheel) >= 0.1f) {
            _armory.SendWeaponID(true);
        }
        else if (Input.GetAxis(MouseScrollWheel) < 0f) {
            _armory.SendWeaponID(false);
        }
    }

    private void OnKeyDown(KeyDownEvent ev) {
        _armory.SendWeaponID(ev.keyCode);
        Debug.Log($"{ev.keyCode}");
    }
}
