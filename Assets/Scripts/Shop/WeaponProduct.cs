using UnityEngine;

[CreateAssetMenu(fileName = "WeaponProduct", menuName = "SO/Shop/WeaponProduct")]
public class WeaponProduct : ShopProduct
{
    [field: SerializeField] public WeaponType WeaponType { get; private set; }
}
