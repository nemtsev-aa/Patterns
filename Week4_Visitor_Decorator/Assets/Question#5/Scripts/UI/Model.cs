using UnityEngine;

public class Model : MonoBehaviour {
    [field: SerializeField] public Races Race { get; private set; }
    [field: SerializeField] public Specializations Specialization { get; private set; }
}
