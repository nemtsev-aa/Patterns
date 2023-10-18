using UnityEngine;

public class MoveEffector : MonoBehaviour {
    private Character _character;
    private IMoveEffect _currentEffect;

    public void Init(Character character) {
        _character = character;
    }

    public void SetMoveEffect(IMoveEffect moveEffect) {
        _currentEffect = moveEffect;
        _currentEffect.Init(_character);
        _currentEffect.TakeEffect();
    }
}
