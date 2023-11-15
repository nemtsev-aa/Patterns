using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorConfig : ScriptableObject {
    public abstract List<Modifiers> GetModifiers();
}
