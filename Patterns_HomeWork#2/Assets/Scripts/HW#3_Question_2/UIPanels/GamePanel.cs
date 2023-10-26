using UnityEngine;

public class GamePanel : UIPanel {
    [SerializeField] private HealthView _healthView;
    [SerializeField] private ExperienceLevelView _levelView;

    public override void Init(GameplayMediator mediator) {
        base.Init(mediator);

        Character character = mediator.Level.Character;
        _healthView.Init(character.Health);
        _levelView.Init(character.ExperienceCounter);
    }
}