using UnityEngine;

public class MeleeAreaAttack : MonoBehaviour, IAreaAttacking
{
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private Transform _attackPoint;
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _radius;
    [SerializeField, Min(0)] private float _cooldown;

    public Transform AttackPoint => _attackPoint;

    public float Damage
    {
        get => _damage;
        private set => _damage = value;
    }
    
    public float Radius
    {
        get => _radius;
        private set => _radius = value;
    }
    
    public float Cooldown
    {
        get => _cooldown;
        private set => _cooldown = value;
    }

    public float RemainingTime { get; private set; }

    public bool CanAttack { get; private set; }

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

    public void Attack()
    {
        if (CanAttack == false)
            return;
            
        CanAttack = false;
        PhysicalAttack();
    }

    private void PhysicalAttack()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll( _attackPoint.position, Radius, _targetLayerMask );

        foreach (var collider2D in colliders2D)
        {
            if (collider2D.TryGetComponent<Player>(out var player))
                player.Health.ApplyDamage(Damage);
        }
    }
}
