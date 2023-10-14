using System;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{    
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _wallet = _wallet ?? throw new NullReferenceException(nameof(_wallet));
        _text = _text ?? throw new NullReferenceException(nameof(_text));
        
        SetMoney(_wallet.Money);
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += SetMoney;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= SetMoney;
    }

    private void SetMoney(int money)
        => _text.text = money.ToString();
}
