using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {
    public override void Shoot() {
        _lastShootTime = Time.time;
        // Создать пулю/пули
        _bulletCreator.CreateBullets(out int createdBulletsNumber);
        // Подсчитать оставшееся количество патронов
        _bulletCounter.TakeBullets(createdBulletsNumber);
    }
}
