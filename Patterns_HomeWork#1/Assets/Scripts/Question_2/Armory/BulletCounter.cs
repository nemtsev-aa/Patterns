using System;

public class BulletCounter {
    private int _currentNumber;
    private int _maxNumber;

    public BulletCounter(int maxNumber) {
        _maxNumber = _currentNumber = maxNumber;
    }

    public int MaxNumber => _maxNumber;
    public int NumberOfBullets => _currentNumber;

    public event Action<int> BulletsCountChanged;
    public event Action BulletsOut;

    public void TakeBullets(int value) {
        if (value <= 0)
            throw new ArgumentOutOfRangeException($"Invalid bullet count {value}");

        _currentNumber -= value;
        
        if (_currentNumber <= 0) {
            _currentNumber = 0;
            BulletsOut?.Invoke();
        } 
        else 
            BulletsCountChanged?.Invoke(_currentNumber); 
    }

    public void AddBullets(int value) {
        if (value < 0)
            throw new ArgumentOutOfRangeException($"Invalid bullet count {value}");

        _currentNumber += value;

        if (_currentNumber > MaxNumber)
            _currentNumber = MaxNumber;

        BulletsCountChanged?.Invoke(_currentNumber);
    }
}
