using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour {
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const int ShootButtonIndex = 0;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseScrollWheel = "Mouse ScrollWheel";

    [SerializeField] private float _mouseSensetivity = 2f;

    private bool _hideCursor;

    public event Action<InputData> InputDataChanged;
    public event Action MouseLeftClicked;
    public event Action<bool> MouseScrolled;
    public event Action<KeyCode> KeyDown;

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

        float rotateX = -mouseY * _mouseSensetivity;
        float rotateY = mouseX * _mouseSensetivity;

        float horizontalAxisValue = Input.GetAxis(Horizontal);
        float verticalAxisValue = Input.GetAxis(Vertical);

        InputData inputData = new InputData(rotateX, rotateY, horizontalAxisValue, verticalAxisValue);
        InputDataChanged?.Invoke(inputData);

        if (isShoot)
            MouseLeftClicked?.Invoke();

        if (Input.GetAxis(MouseScrollWheel) >= 0.1f) {
            MouseScrolled?.Invoke(true);
        }
        
        if (Input.GetAxis(MouseScrollWheel) < 0f) {
            MouseScrolled?.Invoke(false);
        }
    }

    private void OnKeyDown(KeyDownEvent ev) {
        KeyDown?.Invoke(ev.keyCode);
    }
}
