using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponFactory", menuName = "SO/Factory/WeaponFactory")]
public class WeaponFactory : ScriptableObject
{
    [SerializeField] private GameObject _shotgunPrefab;
    [SerializeField] private GameObject _pistolPrefab;
    [SerializeField] private GameObject _uziPrefab;
    
    private Transform _container;

    public void Init(Transform container)
    {
        _container = container ?? throw new NullReferenceException(nameof(container));
        CheckPrefabs();
    }

    public Weapon Create(ItemType weaponType)
    {
        switch (weaponType)
        {
            case ItemType.WeaponShotgun:
                return Create(_shotgunPrefab);
        
            case ItemType.WeaponPistol:
                return Create(_pistolPrefab);
            
            case ItemType.WeaponUzi:
                return Create(_uziPrefab);
        
            default:
                throw new ArgumentException($"Not correct type {weaponType}");
        }
    }

    private Weapon Create(GameObject prefab)
    {
        var newGameObject = Instantiate(prefab, _container);
        return newGameObject.GetComponent<Weapon>();
    }

    private void CheckPrefabs()
    {
        CheckForNull(_shotgunPrefab);
        CheckForNull(_pistolPrefab);
        CheckForNull(_uziPrefab);
    }

    private void CheckForNull(GameObject gameObject)
    {
        if (gameObject == null)
            throw new NullReferenceException(nameof(gameObject));
    }
}
