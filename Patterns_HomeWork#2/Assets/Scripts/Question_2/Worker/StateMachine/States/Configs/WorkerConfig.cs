using UnityEngine;

[CreateAssetMenu(fileName = "WorkerConfig", menuName = "Configs/WorkerConfig")]
public class WorkerConfig : ScriptableObject {
    [SerializeField] private ToWorkStateConfig _toWorkStateConfig;
    [SerializeField] private IsWorkStateConfig _isWorkStateConfig;
    [SerializeField] private FromWorkStateConfig _fromWorkStateConfig;
    [SerializeField] private RelaxingStateConfig _relaxingStateConfig;

    public ToWorkStateConfig ToWorkStateConfig => _toWorkStateConfig;
    public IsWorkStateConfig IsWorkStateConfig => _isWorkStateConfig;
    public FromWorkStateConfig FromWorkStateConfig => _fromWorkStateConfig;
    public RelaxingStateConfig RelaxingStateConfig => _relaxingStateConfig;
}
