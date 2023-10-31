using UnityEngine;

public class BulletLoot : MonoBehaviour {
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numberOfBullets;

    public int GunIndex => _gunIndex;
    public int NumberOfBullets => _numberOfBullets;
}