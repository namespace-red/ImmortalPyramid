using System;
using UnityEngine;

public class Pistol : Weapon
{
    private void Awake()
    {
        if (Bullet == null) throw new NullReferenceException(nameof(Bullet));
        
        ItemType = ItemType.WeaponPistol;
    }
    
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
