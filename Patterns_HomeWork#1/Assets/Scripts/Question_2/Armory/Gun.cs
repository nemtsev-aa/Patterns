using UnityEngine;

public class Gun : Weapon {
    public override void Shoot() {
        _lastShootTime = Time.time;
        // ������� ����/����
        _bulletCreator.CreateBullets(out int createdBulletsNumber);
    }
}
