using System;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public UnityAction<int> MoneyChanged;
    
    [SerializeField] private int _money;
    private IPersistentData _persistentData;
    
    [field: SerializeField, Min(0)] public int MaxMoney { get; private set; } = 1000;

    public int Money
    {
        get => _money;
        private set
        {
            _money = value;
            _persistentData.PlayerData.Money = value;
            MoneyChanged?.Invoke(Money);
        }
    }

    public void Init(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        Money = _persistentData.PlayerData.Money;
    }
    
    public bool TryAddMoney(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (Money + value > MaxMoney)
            return false;

        Money += value;
        return true;
    }

    public bool TryTakeMoney(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (Money < value)
            return false;

        Money -= value;
        return true;
    }
}
