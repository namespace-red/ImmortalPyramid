using System;
using UnityEngine;

public class Shotgun : Weapon
{
    private void Awake()
    {
        if (Bullet == null) throw new NullReferenceException(nameof(Bullet));
        
        ItemType = ItemType.WeaponShotgun;
    }
    
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
