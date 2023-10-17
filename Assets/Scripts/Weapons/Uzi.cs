using System;
using UnityEngine;

public class Uzi : Weapon
{
    private void Awake()
    {
        if (Bullet == null) throw new NullReferenceException(nameof(Bullet));
        
        ItemType = ItemType.WeaponUzi;
    }
    
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
