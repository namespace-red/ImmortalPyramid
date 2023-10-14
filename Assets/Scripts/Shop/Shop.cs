using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "SO/Shop/Shop")]
public class Shop : ScriptableObject
{
    public bool TryBuy(ShopProduct product, ShopClient client)
    {
        bool isBuyed = client.Wallet.TryTakeMoney(product.Price);
		
        if (isBuyed)
        {
            client.GiveProduct(product.Model);
            product.IsBuyed = true;
        }
		
        return isBuyed;
    }
}