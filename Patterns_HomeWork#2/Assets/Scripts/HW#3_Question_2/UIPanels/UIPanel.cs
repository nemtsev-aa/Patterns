using UnityEngine;

public class UIPanel : MonoBehaviour, IPanel {
    protected GameplayMediator Mediator;

    public virtual void Init(GameplayMediator mediator) {
        Mediator = mediator;
        Hide();
    }

    public virtual void Show() => gameObject.SetActive(true);

    public virtual void Hide() => gameObject.SetActive(false);
}
