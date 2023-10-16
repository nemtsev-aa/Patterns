using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {
    [Header("Move Settings")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] float _minHeadAngle = -90f;
    [SerializeField] float _maxHeadAngle = 90f;
    [Header("Vision Settings")]
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] Transform _head;

    private float _inputH;
    private float _inputV;
    private float _rotateX;
    private float _rotateY;
    private float _currentRotateX;

    private void Start() {
        Transform camera = Camera.main.transform;
        camera.parent = _cameraPoint;
        camera.localPosition = Vector3.zero;
        camera.localRotation = Quaternion.identity;
    }

    private void Update() {
        RotateX(_rotateX);
    }

    private void FixedUpdate() {
        Move();
        RotateY();
    }

    public void SetInput(float h, float v, float rotateX, float rotateY) {
        _inputH = h;
        _inputV = v;
        _rotateX = rotateX;
        _rotateY += rotateY;
    }

    public void SetInput() {

    }

    private void Move() {
        Vector3 velocity = (transform.forward * _inputV + transform.right * _inputH).normalized * Speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    public void GetMoveInfo(out Vector3 position, out Vector3 velocity, out float rotateX, out float rotateY) {
        position = transform.position;
        velocity = _rigidbody.velocity;
        rotateX = _head.localEulerAngles.x;
        rotateY = transform.eulerAngles.y;
    }

    public void RotateX(float value) {
        _currentRotateX = Mathf.Clamp(_currentRotateX + value, _minHeadAngle, _maxHeadAngle);
        _head.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
    }

    private void RotateY() {
        _rigidbody.angularVelocity = new Vector3(0f, _rotateY, 0f);
        _rotateY = 0;
    }
}
