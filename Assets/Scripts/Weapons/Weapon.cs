using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected Bullet Bullet;

    public abstract void Shoot(Transform shootPoint);
}
