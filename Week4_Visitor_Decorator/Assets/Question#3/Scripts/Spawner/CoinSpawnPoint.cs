using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour {
    private Coin _coin;
    
    public bool IsEmpty {
        get {
            if (_coin == null)
                return true;
            else
                return false;
        }
    }
    
    public void Init(Coin coin) {
        _coin = coin;
    }
}