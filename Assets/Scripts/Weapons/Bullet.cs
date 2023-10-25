using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _damage;
    private Rigidbody2D _rigidbody2D;

    public void Init(float damage)
    {
        _damage = damage;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector3.left * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
        }
        
        Destroy(gameObject);
    }
}
