using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopProductView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _verifiedImage;

    public UnityAction<ShopProductView> BuyButtonClicked;
    
    public ShopProduct Product { get; private set; }

    private void OnEnable()
        => _buyButton.onClick.AddListener(OnClickButton);
    
    private void OnDisable()
        => _buyButton.onClick.RemoveListener(OnClickButton);

    private void Awake()
    {
        _label = _label ?? throw new NullReferenceException(nameof(_label));
        _price = _price ?? throw new NullReferenceException(nameof(_price));
        _icon = _icon ?? throw new NullReferenceException(nameof(_icon));
        _buyButton = _buyButton ?? throw new NullReferenceException(nameof(_buyButton));
        _verifiedImage = _verifiedImage ?? throw new NullReferenceException(nameof(_verifiedImage));
    }

    public void Init(ShopProduct shopProduct)
    {
        Product = shopProduct;

        _label.text = Product.Label;
        _price.text = Product.Price.ToString();
        _icon.sprite = Product.Icon;

        SetBuyed(Product.IsBought);
    }

    public void SetBuyed(bool state)
    {
        _verifiedImage.gameObject.SetActive(state);
        _buyButton.gameObject.SetActive(!state);
    }

    private void OnClickButton()
    {
        BuyButtonClicked?.Invoke(this);
    }
}
