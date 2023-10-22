using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}
