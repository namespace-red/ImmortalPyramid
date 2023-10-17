using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "SO/Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private GameObject _minotaurPrefab;
    [SerializeField] private GameObject _skeletonPrefab;
    
    private ITargetWithHeathData _target;
    private Transform _spawnPoint;

    public void Init(Transform spawnPoint, ITargetWithHeathData target)
    {
        _spawnPoint = spawnPoint ?? throw new NullReferenceException(nameof(spawnPoint));
        _target = target ?? throw new NullReferenceException(nameof(target));
        CheckPrefabs();
    }

    public Enemy Create(EnemyType enemyType)
    {
        Enemy newEnemy;
        
        switch (enemyType)
        {
            case EnemyType.Minotaur:
                newEnemy = Create(_minotaurPrefab);
                ((Minotaur)newEnemy).Init(_target);
                break;

            case EnemyType.Skeleton:
                newEnemy = Create(_skeletonPrefab);
                ((Skeleton)newEnemy).Init(_target);
                break;
            
            default:
                throw new ArgumentException($"Not correct type {enemyType}");
        }

        return newEnemy;
    }
    
    private Enemy Create(GameObject prefab)
    {
        var newGameObject = Instantiate(prefab, _spawnPoint);
        return newGameObject.GetComponent<Enemy>();
    }

    private void CheckPrefabs()
    {
        CheckForNull(_minotaurPrefab);
        CheckForNull(_skeletonPrefab);
    }

    private void CheckForNull(GameObject gameObject)
    {
        if (gameObject == null)
            throw new NullReferenceException(nameof(gameObject));
    }
}
