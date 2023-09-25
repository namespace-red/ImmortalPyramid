using UnityEngine;

public class MeleeAreaAttack : MonoBehaviour, IAreaAttacking
{
    [SerializeField] LayerMask _targetLayerMask;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _damage = 5;
    
    private float Cooldown { get; set; }
    private float RemainingTime { get; set; }
    
    public bool CanAttack { get; private set; }
    public float Radius { get;  set; }

    private void Start()
    {
        Cooldown = 3;
    }

    private void Update()
    {
        if (CanAttack)
            return;

        if (RemainingTime > 0)
            RemainingTime -= Time.deltaTime;

        if (RemainingTime > 0) return;
            
        RemainingTime = Cooldown;
        CanAttack = true;
    }

    public void Attack()
    {
        if (!CanAttack)
            return;
            
        CanAttack = false;
        FisycalAttack();
    }

    private void FisycalAttack()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll( _attackPoint.position, Radius, _targetLayerMask );

        foreach (var collider2D in colliders2D)
        {
            if (collider2D.TryGetComponent<Player>(out var player))
                player.Health.ApplyDamage(_damage);
        }
    }
}
