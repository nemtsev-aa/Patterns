using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour {
    [Tooltip("������ ����")]
    [SerializeField] private Bullet _bulletPrafab;
    [Tooltip("������������ ���������� ����")]
    [SerializeField] private Transform _bulletCreatorTransform;
    [Tooltip("������ ����� ��� ������ ����")]
    [SerializeField] private Transform[] _bulletCreatorPoints = new Transform[0];

    public void Init() {
        if (CreatePointsList() != null) _bulletCreatorPoints = CreatePointsList().ToArray();
    }

    public void CreateBullets(out int createdBulletsNumber) {
        createdBulletsNumber = 0;

        Vector3 velocity = transform.forward;

        foreach (var iPoint in _bulletCreatorPoints) {
            Bullet newBullet = Instantiate(_bulletPrafab, iPoint.position, iPoint.rotation);
            newBullet.Init(velocity);
            createdBulletsNumber++;
        }
    }

    private List<Transform> CreatePointsList() {
        if (_bulletCreatorTransform == null) {
            Debug.LogError("��������� ���������� ���� �� �����������!");
            return null;
        } else {
            /// ������ ������ ����� ��� ������ ���� �� �������� �������� ����������
            List<Transform> childrenList = new List<Transform>();
            if (_bulletCreatorTransform.transform.childCount > 1) {
                foreach (Transform child in _bulletCreatorTransform) {
                    childrenList.Add(child);
                }
            } else {
                childrenList.Add(_bulletCreatorTransform);
            }
            return childrenList;
        }
    }
}
