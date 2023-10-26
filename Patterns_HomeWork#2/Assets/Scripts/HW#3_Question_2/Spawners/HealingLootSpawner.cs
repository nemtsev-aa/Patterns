using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLootSpawner : ObjectsSpawnerBase {
    [SerializeField] private HealingLootFactory _factory;

    private List<HealingTrigger> _healingTriggers;

    public override void Reset() {
        StopWork();

        foreach (var iTrigger in _healingTriggers) {
            Destroy(iTrigger.gameObject);
        }

        _healingTriggers.Clear();
    }

    public override IEnumerator SpawnObjects() {
        _healingTriggers = new List<HealingTrigger>();

        foreach (var iTransform in SpawnPoints) {
            HealingTrigger trigger = _factory.Get(GetRamdomType(), transform);
            
            trigger.transform.position = iTransform.position;
            trigger.Destroyed += RemoveFromList;
            
            _healingTriggers.Add(trigger);
            
            yield return new WaitForSeconds(SpawnCooldown);
        }
    }

    private HealingLootType GetRamdomType() {
        return (HealingLootType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(HealingLootType)).Length);
    }

    private void RemoveFromList(HealthBaseTrigger trigger) {
        trigger.Destroyed -= RemoveFromList;
        _healingTriggers.Remove((HealingTrigger)trigger);
        Destroy(trigger.gameObject);
    }
}
