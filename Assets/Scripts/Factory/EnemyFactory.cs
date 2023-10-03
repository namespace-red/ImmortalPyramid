using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _targetObjContainer;
    [SerializeField] private Transform _spawnPoint;
    
    private const string Folder = "Prefabs/";
    private ITargetWithHeathData _target;

    private void Start()
    {
        _targetObjContainer = _targetObjContainer ?? throw new ArgumentException("EnemyFactory._targetObjContainer can't be null");
        
        if (_targetObjContainer.TryGetComponent<ITargetWithHeathData>(out _target) == false)
            throw new ArgumentException("EnemyFactory._targetObjContainer doesn't have ITargetWithHeathData");
        
        _spawnPoint = _spawnPoint ?? throw new ArgumentException("EnemyFactory._spawnPoint can't be null");
    }

    public Enemy Create(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Minotaur:
                return CreateMinotaur();
            
            case EnemyType.Skeleton:
                return CreateSkeleton();
            
            default:
                throw new ArgumentException("Not correct EnemyType");
        }
    }
    
    public Enemy CreateMinotaur()
    {
        var prifab = Resources.Load<GameObject>( Folder + "Minotaur");
        var newGameObject = Instantiate(prifab, _spawnPoint);
        var minotaur = newGameObject.GetComponent<Minotaur>();
        minotaur.Init(_target);
        return minotaur;
    }
    
    public Enemy CreateSkeleton()
    {
        var prifab = Resources.Load<GameObject>( Folder + "Skeleton");
        var newGameObject = Instantiate(prifab, _spawnPoint);
        var skeleton = newGameObject.GetComponent<Skeleton>();
        skeleton.Init(_target);
        return skeleton;
    }
}
