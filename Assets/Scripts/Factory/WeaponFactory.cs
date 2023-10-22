using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponFactory", menuName = "SO/Factory/WeaponFactory")]
public class WeaponFactory : ScriptableObject
{
    [SerializeField] private BulletFactory _bulletFactory;
    [SerializeField] private GameObject _shotgunPrefab;
    [SerializeField] private GameObject _pistolPrefab;
    [SerializeField] private GameObject _uziPrefab;
    
    private Transform _container;

    public void Init(Transform container)
    {
        if (_bulletFactory == null) throw new NullReferenceException(nameof(_bulletFactory));
        _container = container ?? throw new NullReferenceException(nameof(container));
        CheckPrefabs();
    }

    public Weapon Create(ItemType weaponType)
    {
        Weapon newWeapon;
        
        switch (weaponType)
        {
            case ItemType.WeaponShotgun:
                newWeapon = Create(_shotgunPrefab);
                break;
        
            case ItemType.WeaponPistol:
                newWeapon =  Create(_pistolPrefab);
                break;
            
            case ItemType.WeaponUzi:
                newWeapon =  Create(_uziPrefab);
                break;
        
            default:
                throw new ArgumentException($"Not correct type {weaponType}");
        }

        newWeapon.Init(_bulletFactory);
        return newWeapon;
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
