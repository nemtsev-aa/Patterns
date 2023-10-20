using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour {
    private const string IsIdling = "IsIdling";
    private const string IsGrounded = "IsGrounded";
    private const string IsJumping = "IsJumping";
    private const string IsFalling = "IsFalling";
    private const string IsAirborne = "IsAirborne";
    private const string IsMovement = "IsMovement";
    private const string IsSlowRunning = "IsSlowRunning";
    private const string IsRunning = "IsRunning";
    private const string IsFastRunning = "IsFastRunning";

    private const string SpeedMultiplier = "SpeedMultiplier";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StopFalling() => _animator.SetBool(IsFalling, false);

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartMovement() => _animator.SetBool(IsMovement, true);
    public void StopMovement() => _animator.SetBool(IsMovement, false);

    public void StartSlowRunning() => _animator.SetBool(IsSlowRunning, true);
    public void StopSlowRunning() => _animator.SetBool(IsSlowRunning, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartFastRunning() => _animator.SetBool(IsFastRunning, true);
    public void StopFastRunning() => _animator.SetBool(IsFastRunning, false);

    public void SetSpeedMultiplier(float value) {
        _animator.SetFloat(SpeedMultiplier, value);
    }
}
