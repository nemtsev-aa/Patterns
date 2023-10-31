using System;
using UnityEngine;

public class InfiniteAmmoWeapon : Weapon {
    [SerializeField] private string _infiniteChar = "∞";

    public string InfiniteChar => _infiniteChar;
    
    public event Action<string> Activated;

    public override void Activate() {
        base.Activate();
        Activated?.Invoke(_infiniteChar);
    }

    protected override bool CheckBulletCount() {
        return true;
    }

    protected override void TakeBullets(int number) { }
}