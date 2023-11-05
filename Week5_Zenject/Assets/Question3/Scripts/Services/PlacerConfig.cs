using UnityEngine;

[CreateAssetMenu(fileName = "PlacerConfig", menuName = "Configs/Q3_PlacerConfig")]
public class PlacerConfig : ScriptableObject {
    [SerializeField] private int _sphereCount = 16;
    [SerializeField] private int _columnCount = 4;
    [SerializeField] private Vector3 _startPos = Vector3.zero;
    [SerializeField] private Vector3 _offset = Vector3.zero;

    public int SphereCount => _sphereCount;
    public int ColumnCount => _columnCount;
    public Vector3 StartPosition => _startPos;
    public Vector3 Offset => _offset;
}