using System;
using UnityEngine;

public class BulletCounter : MonoBehaviour {
    [Tooltip("Максимальное количество пуль")]
    [field: SerializeField] public int MaxNumber { get; private set; }
    public int NumberOfBullets => _currentNumber;

    public event Action<int> OnBulletsCountChanged;
    public event Action OnBulletsOut;

    private int _currentNumber;

    private void OnValidate() {
        _currentNumber = MaxNumber;
    }

    public void TakeBullets(int value) {
        _currentNumber -= value;
        if (_currentNumber <= 0) {
            _currentNumber = 0;
            OnBulletsOut?.Invoke();
        } else {
            OnBulletsCountChanged?.Invoke(_currentNumber);
        }
    }

    public void AddBullets(int value) {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

        _currentNumber += value;
        if (_currentNumber > MaxNumber) _currentNumber = MaxNumber;
        OnBulletsCountChanged?.Invoke(_currentNumber);
    }
}
