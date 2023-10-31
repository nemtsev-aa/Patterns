public class InputData {
    private float _rotateX;
    private float _rotateY;

    private float _horizontalAxisValue;
    private float _verticalAxisValue;

    public InputData(float rotateX, float rotateY, float horizontalAxisValue, float verticalAxisValue) {
        _rotateX = rotateX;
        _rotateY = rotateY;
        _horizontalAxisValue = horizontalAxisValue;
        _verticalAxisValue = verticalAxisValue;
    }

    public float RotateX => _rotateX;
    public float RotateY => _rotateY;
    public float HorizontalAxisValue => _horizontalAxisValue;
    public float VerticalAxisValue => _verticalAxisValue;
}
