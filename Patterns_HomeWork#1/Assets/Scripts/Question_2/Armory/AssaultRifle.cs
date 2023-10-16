using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon {
    public override void Shoot() {
        _lastShootTime = Time.time;
        // ������� ����/����
        _bulletCreator.CreateBullets(out int createdBulletsNumber);
        // ���������� ���������� ���������� ��������
        _bulletCounter.TakeBullets(createdBulletsNumber);
    }
}
