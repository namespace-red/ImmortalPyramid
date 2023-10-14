using System;
using UnityEngine;

public class Shotgun : Weapon
{
    private void Awake()
    {
        Bullet = Bullet ?? throw new NullReferenceException("Shotgun.Bullet can't be null");
    }
    
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
