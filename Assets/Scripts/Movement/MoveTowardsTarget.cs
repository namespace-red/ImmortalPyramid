using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour, IMovableTowardsTarget
{
    [SerializeField] private float _speed;
    
    public Transform Target { get; }
    
    public bool IsMoving { get; private set; }

    private void Update()
    {
        if (IsMoving == false)
            return;
        
        transform.Translate( Vector2.right * _speed * Time.deltaTime, Space.World);
    }
    
    public void Move()
    {
        IsMoving = true;
    }

    public void Stop()
    {
        IsMoving = false;
    }
}
