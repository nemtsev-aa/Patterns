using UnityEngine;

public class Gun : Weapon {
    public override void Shoot() {
        _lastShootTime = Time.time;
        // Создать пулю/пули
        _bulletCreator.CreateBullets(out int createdBulletsNumber);
    }
}
