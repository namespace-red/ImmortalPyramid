using System;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] private float _damage;
    [SerializeField, Min(0)] private float _cooldown;
    private BulletFactory _bulletFactory;

    public float Damage => _damage;

    public float Cooldown
    {
        get => _cooldown;
        private set => _cooldown = value;
    }

    [field: SerializeField] public float RemainingTime { get; private set; }

    public bool CanAttack { get; private set; }

    public void Init(BulletFactory bulletFactory)
    {
         _bulletFactory = bulletFactory ?? throw new NullReferenceException(nameof(bulletFactory));
    }
    
    private void Update()
    {
        if (CanAttack)
            return;

        if (RemainingTime > 0)
            RemainingTime -= Time.deltaTime;
        
        if (RemainingTime > 0) 
            return;
            
        RemainingTime = Cooldown;
        CanAttack = true;
    }

    public void Shoot(Transform shootPoint)
    {
        if (CanAttack == false)
            return;
            
        CanAttack = false;
        _bulletFactory.Create(Damage);
    }

}
