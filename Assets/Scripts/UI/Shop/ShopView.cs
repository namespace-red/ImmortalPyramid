using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Transform _productsContainer;
    [SerializeField] private ShopProductViewFactory _shopProductViewFactory;
    [SerializeField] private ShopContent _shopContent;
    [SerializeField] private Shop _shop;
    [SerializeField] private ShopClient _client;

    private List<ShopProductView> _productViews = new List<ShopProductView>();

    private void Awake()
    {
        _productsContainer = _productsContainer ?? throw new NullReferenceException(nameof(_productsContainer));
        _shopProductViewFactory = _shopProductViewFactory ?? throw new NullReferenceException(nameof(_shopProductViewFactory));
        _shopContent = _shopContent ?? throw new NullReferenceException(nameof(_shopContent));
        _shop = _shop ?? throw new NullReferenceException(nameof(_shop));
        _client = _client ?? throw new NullReferenceException(nameof(_client));
    }

    private void OnEnable()
    {
        Show(_shopContent.Products);
    }
    
    private void Show(IEnumerable<ShopProduct> products)
    {
        Clear();
        
        foreach (var product in products)
        {
            ShopProductView shopProductView = _shopProductViewFactory.Create(product, _productsContainer);
            shopProductView.BuyButtonClicked += OnBuyButtonClicked;
            
            _productViews.Add(shopProductView);
        }
    }

    private void Clear()
    {
        foreach (var productView in _productViews)
        {
            productView.BuyButtonClicked -= OnBuyButtonClicked;
            Destroy(productView.gameObject);
        }
        
        _productViews.Clear();
    }
    
    private void OnBuyButtonClicked(ShopProductView productView)
    {
        productView.SetBuyed(_shop.TryBuy(productView.Product, _client));
    }
}
