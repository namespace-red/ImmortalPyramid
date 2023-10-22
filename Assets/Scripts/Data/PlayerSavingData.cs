using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PlayerSavingData
{
    private int _money;
    private int _currentItemIndex;

    public PlayerSavingData()
    {
        Inventory = new List<ItemType> { ItemType.WeaponShotgun };
    }

    [JsonConstructor]
    public PlayerSavingData(IEnumerable<ItemType> inventory, int money, int currentItemIndex)
    {
        Inventory = new List<ItemType>(inventory);
        Money = money;
        CurrentItemIndex = currentItemIndex;
    }

    public int Money
    {
        get => _money;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _money = value;
        }
    }

    public List<ItemType> Inventory { get; }

    public int CurrentItemIndex
    {
        get => _currentItemIndex;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

            _currentItemIndex = value;
        }
    }
}
