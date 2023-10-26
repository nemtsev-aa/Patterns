using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ObjectsSpawnerBase {
    [SerializeField] private ObstacleFactory _obstacleFactory;

    private List<DamageTrigger> _damageTriggers;

    public override void Reset() {
        StopWork();

        foreach (var iTrigger in _damageTriggers) {
            Destroy(iTrigger.gameObject);
        }

        _damageTriggers.Clear();
    }

    public override IEnumerator SpawnObjects() {
        _damageTriggers = new List<DamageTrigger>();

        foreach (var iTransform in SpawnPoints) {
            DamageTrigger trigger = _obstacleFactory.Get(GetRamdomType(), transform);
            trigger.transform.position = iTransform.position;
            trigger.Destroyed += RemoveFromList;

            _damageTriggers.Add(trigger);

            yield return new WaitForSeconds(SpawnCooldown);
        }
    }

    private DamageType GetRamdomType() {
        return (DamageType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(DamageType)).Length);
    }

    private void RemoveFromList(HealthBaseTrigger trigger) {
        trigger.Destroyed -= RemoveFromList;
        _damageTriggers.Remove((DamageTrigger)trigger);
        Destroy(trigger.gameObject);
    }
}