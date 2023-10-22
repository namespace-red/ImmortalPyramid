using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletFactory", menuName = "SO/Factory/BulletFactory")]
public class BulletFactory : ScriptableObject
{
    [SerializeField] private GameObject _bulletPrefab;
    
    private Transform _shootPoint;

    public void Init(Transform shootPoint)
    {
        _shootPoint = shootPoint ?? throw new NullReferenceException(nameof(shootPoint));
        CheckPrefabs();
    }

    public void Create(float damage)
    {
        var bullet = Create(_bulletPrefab);
        bullet.Init(damage);
    }

    private Bullet Create(GameObject prefab)
    {
        var newGameObject = Instantiate(prefab, _shootPoint);
        return newGameObject.GetComponent<Bullet>();
    }

    private void CheckPrefabs()
    {
        CheckForNull(_bulletPrefab);
    }

    private void CheckForNull(GameObject gameObject)
    {
        if (gameObject == null)
            throw new NullReferenceException(nameof(gameObject));
    }
}