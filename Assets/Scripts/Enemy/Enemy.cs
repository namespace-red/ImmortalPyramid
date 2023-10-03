using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    private Collider2D _targetCollider2D;
    
    public EnemyType EnemyType { get; protected set; }
    public Health Health { get; protected set; }
    public IMovableTowardsTarget Move { get; protected set; }
    public IAttacking Attack { get; protected set; }
    
    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
            return;
        
        if (_targetCollider2D == null)
            _targetCollider2D = Move.Target.GetComponent<Collider2D>();
        
        // Line from Attack point to Player
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Attack.AttackPoint.position, 
            _targetCollider2D.ClosestPoint(Attack.AttackPoint.position));
        
        // Attack circle
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(Attack.AttackPoint.position ,Vector3.back, Attack.Radius);
    }   
}
