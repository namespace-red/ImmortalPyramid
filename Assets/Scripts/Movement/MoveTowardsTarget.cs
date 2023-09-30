using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowardsTarget : MonoBehaviour, IMovableTowardsTarget
{
    [SerializeField, Min(0)] private float _speed;
    private Rigidbody2D _rigidbody;
    
    public Transform Target { get; set; }
    
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (IsMoving)
            Move();
    }
    
    public void StartMove()
    {
        IsMoving = true;
        
        if (Target == null)
            Debug.LogError("MoveTowardsTarget.Target is null");
    }

    public void StopMove()
    {
        IsMoving = false;
    }

    private void Move()
    {
        var normal = GetNormalDirection();
        _rigidbody.MovePosition(transform.position + (normal * _speed * Time.fixedDeltaTime));
    }

    private Vector3 GetNormalDirection()
    {
        return (Target.position - transform.position).normalized;
    }
}
