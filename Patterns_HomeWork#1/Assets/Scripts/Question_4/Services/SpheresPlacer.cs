using System.Collections.Generic;
using UnityEngine;

public class SpheresPlacer : MonoBehaviour, IService {
    [SerializeField] private int _columnCount = 4;
    [SerializeField] private Vector3 _startPos = Vector3.zero;
    [SerializeField] private Vector3 _offset = Vector3.zero;
    
    private List<Vector3> _positions;
    private int _sphereCount;
    private int _rowCount;

    public IEnumerable<Vector3> Positions => _positions;

    public void Init(int sphereCount) {
        _sphereCount = sphereCount;
        _rowCount = _sphereCount / _columnCount;

        CreatePositions();
    }

    public void Restart() {
        _startPos = Vector3.zero;
        _positions = null;
    }

    private void CreatePositions() {
        _positions = new List<Vector3>();
        int id = 0;
        float posXreset = _startPos.x;
        for (int y = 0; y < _columnCount; y++) {
            _startPos.y -= _offset.y;
            for (int x = 0; x < _rowCount; x++) {
                id++;
                _startPos.x += _offset.x;
                _positions.Add(new Vector2(_startPos.x, _startPos.y));
            }
            _startPos.x = posXreset;
        }
    }
}
