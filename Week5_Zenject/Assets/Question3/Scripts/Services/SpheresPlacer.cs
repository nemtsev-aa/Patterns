using System.Collections.Generic;
using UnityEngine;

namespace Question3 {
    public class SpheresPlacer : IService {
        private int _columnCount = 4;
        private Vector3 _startPos = Vector3.zero;
        private Vector3 _offset = Vector3.zero;

        private List<Vector3> _positions;
        private int _sphereCount;
        private int _rowCount;

        public SpheresPlacer(PlacerConfig config) {
            _columnCount = config.ColumnCount;
            _startPos = config.StartPosition;
            _offset = config.Offset;
            _sphereCount = config.SphereCount;

            StartWork();
        }

        public IEnumerable<Vector3> Positions => _positions;

        public void StartWork() {
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
}