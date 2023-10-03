using UnityEngine;

public interface IAttacking
{
    public Transform AttackPoint { get; }
    public float Radius { get; }
    public bool CanAttack { get; }

    public void Attack();
}
