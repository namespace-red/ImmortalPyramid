using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{ 
    public EnemyType EnemyType { get; protected set; }
    public Health Health { get; protected set; }
    public IMovableTowardsTarget Move { get; protected set; }
    public IAttacking Attack { get; protected set; }
    
    private void OnDrawGizmos()
    {
        // Line to Player
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Move.Target.position);
        
        // Attack circle
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(Attack.AttackPoint.position ,Vector3.back, Attack.Radius);
    }   
}
