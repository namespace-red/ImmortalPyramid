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
        set
        {
            _persistentData.PlayerData.CurrentItemIndex = value;
            Debug.Log(GetCurrentItem().name);
        }
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
    
    public void SelectNextItem()
    {
        if (CurrentItemIndex + 1 == _items.Count)
            CurrentItemIndex = 0;
        else
            ++CurrentItemIndex;
    }
    
    public void SelectPastItem()
    {
        if (CurrentItemIndex - 1 < 0)
            CurrentItemIndex = _items.Count - 1;
        else
            --CurrentItemIndex;
    }
}
