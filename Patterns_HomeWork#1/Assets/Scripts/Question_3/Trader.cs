using UnityEngine;

[RequireComponent(typeof(TraderView))]
public class Trader : MonoBehaviour {
    private TraderBehaviourSwitcher _strategySwitcher;
    private TraderView _traderView;
    private ITrader _traderStrategie;

    public void Init(TraderBehaviourSwitcher strategySwitcher) {
        _strategySwitcher = strategySwitcher;
        _traderView ??= GetComponent<TraderView>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody.TryGetComponent(out ITradable player)) {
            GetStrategie(player);
            StartTrading(player);
        }
    }
    
    private void OnCollisionExit(Collision collision) {
        if (collision.rigidbody.TryGetComponent(out ITradable player))
            ShowView(false);
    }

    private void GetStrategie(ITradable player) {
        _traderStrategie = _strategySwitcher.GetStrategie(player);
    }

    private void StartTrading(ITradable player) {
        transform.LookAt(player.Transform);
        Debug.Log($"{_traderStrategie.Sell()}");
        ShowView(true);
    }

    private void ShowView(bool status) {
        if (status)
            _traderView.ShowParticle(_traderStrategie);
        else
            _traderView.HideParticle();
    }
}
