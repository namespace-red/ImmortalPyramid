using System;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _maxMoney = 100;
    [SerializeField] private int _money;
    
    public UnityAction<int> MoneyChanged;
    
    public int MaxMoney { get; private set; }
    
    public int Money
    {
        get => _money;
        private set
        {
            _money = value;
            MoneyChanged?.Invoke(Money);
        }
    }

    public bool TryAddMoney(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        if (Money + value > _maxMoney)
            return false;

        Money += value;
        return true;
    }

    public bool TryTakeMoney(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        if (Money < value)
            return false;

        Money -= value;
        return true;
    }
}
