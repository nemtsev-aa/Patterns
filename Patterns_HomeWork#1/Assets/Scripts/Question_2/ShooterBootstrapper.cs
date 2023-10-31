using UnityEngine;

public class ShooterBootstrapper : MonoBehaviour {
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private Controller _controller;
    [SerializeField] private Armory _armory;
    
    private Shooter _shooter;

    private void Start() {
        _armory.Init(_controller);
        Shooter _shooter = new Shooter(_controller, _armory);
        _player.Init(_controller, _shooter); 
    }
}