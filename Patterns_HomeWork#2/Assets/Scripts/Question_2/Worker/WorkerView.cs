using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WorkerView : MonoBehaviour {
    private const string ToWork = "ToWork";
    private const string IsWork = "IsWork";
    private const string FromWork = "FromWork";
    private const string IsRelax = "IsRelax";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartToWork() => _animator.SetBool(ToWork, true);
    public void StopToWork() => _animator.SetBool(ToWork, false);

    public void StartIsWork() => _animator.SetBool(IsWork, true);
    public void StopIsWork() => _animator.SetBool(IsWork, false);

    public void StartFromWork() => _animator.SetBool(FromWork, true);
    public void StopFromWork() => _animator.SetBool(FromWork, false);

    public void StartIsRelax() => _animator.SetBool(IsRelax, true);
    public void StopIsRelax() => _animator.SetBool(IsRelax, false);
}
