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

    public void Init(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        _items = _persistentData.PlayerData.Inventory;
    }
    public void Add(Item item)
    {
        _items.Add(item);
    }

    public Item GetCurrentItem()
        => _items[CurrentItemIndex];
    
    public Item GetNextItem()
    {
        if (++CurrentItemIndex == _items.Count)
            CurrentItemIndex = 0;
        
        return _items[CurrentItemIndex];
    }
    
    public Item GetPastItem()
    {
        if (--CurrentItemIndex < 0)
            CurrentItemIndex = _items.Count - 1;
        
        return _items[CurrentItemIndex];
    }
}
