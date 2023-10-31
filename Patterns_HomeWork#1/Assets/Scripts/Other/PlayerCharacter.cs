using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : Character {
    [SerializeField] float _minHeadAngle = -90f;
    [SerializeField] float _maxHeadAngle = 90f;
    
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] Transform _head;

    private Controller _controller;
    private Shooter _shooter;
    private Rigidbody _rigidbody;

    private float _inputH;
    private float _inputV;
    private float _rotateX;
    private float _rotateY;
    private float _currentRotateX;

    public void Init(Controller controller, Shooter shooter) {
        _shooter = shooter;
        _controller = controller;
        _controller.InputDataChanged += SetInput;

        SetCameraInPositon();

        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void OnDisable() {
        _controller.InputDataChanged -= SetInput;
    }

    private void Update() {
        RotateX(_rotateX);
    }

    private void FixedUpdate() {
        Move();
        RotateY();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out BulletLoot loot)) {
            _shooter.AddBullets(loot.GunIndex, loot.NumberOfBullets);
        }
    }

    private void SetCameraInPositon() {
        Transform camera = Camera.main.transform;
        camera.parent = _cameraPoint;
        camera.localPosition = Vector3.zero;
        camera.localRotation = Quaternion.identity;
    }

    private void SetInput(InputData inputData) {
        _inputH = inputData.HorizontalAxisValue;
        _inputV = inputData.VerticalAxisValue;
        _rotateX = inputData.RotateX;
        _rotateY += inputData.RotateY;
    }

    private void Move() {
        Vector3 velocity = (transform.forward * _inputV + transform.right * _inputH).normalized * Speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private void RotateX(float value) {
        _currentRotateX = Mathf.Clamp(_currentRotateX + value, _minHeadAngle, _maxHeadAngle);
        _head.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
    }

    private void RotateY() {
        _rigidbody.angularVelocity = new Vector3(0f, _rotateY, 0f);
        _rotateY = 0;
    }
}
