using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    private IPersistentData _persistentData;

    private int CurrentItemIndex
    {
        get => _persistentData.PlayerData.CurrentItemIndex;
        set => _persistentData.PlayerData.CurrentItemIndex = value;
    }

    public void Init(IPersistentData persistentData, WeaponFactory weaponFactory)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));

        foreach (var item in _persistentData.PlayerData.Inventory)
            _items.Add(weaponFactory.Create(item));
    }
    public void Add(Item item)
    {
        _items.Add(item);
        _persistentData.PlayerData.Inventory.Add(item.ItemType);
    }

    public Item GetCurrentItem()
        => _items[CurrentItemIndex];
    
    public Item GetNextItem()
    {
        if (++CurrentItemIndex == _items.Count)
            CurrentItemIndex = 0;
        
        return GetCurrentItem();
    }
    
    public Item GetPastItem()
    {
        if (--CurrentItemIndex < 0)
            CurrentItemIndex = _items.Count - 1;
        
        return GetCurrentItem();
    }
}
