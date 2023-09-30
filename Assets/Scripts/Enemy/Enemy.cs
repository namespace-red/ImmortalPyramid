using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{ 
    public EnemyType EnemyType { get; protected set; }
    public Health Health { get; protected set; }
    public IMovableTowardsTarget Move { get; protected set; }
    public IAttacking Attack { get; protected set; }
}
