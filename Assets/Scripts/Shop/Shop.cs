using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "SO/Shop/Shop")]
public class Shop : ScriptableObject
{
    public bool TryBuy(ShopProduct product, ShopClient client)
    {
        bool isBought = client.Wallet.TryTakeMoney(product.Price);
		
        if (isBought)
        {
            client.GiveProduct(product.Type);
            product.IsBought = true;
        }
		
        return isBought;
    }
}