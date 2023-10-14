using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerSavingData
{
    public PlayerSavingData()
    {
        var prifab = Resources.Load<GameObject>( "Prefabs/Waepons/Shotgun");
        var newGameObject = GameObject.Instantiate(prifab);
        var defaultItem = newGameObject.GetComponent<Shotgun>();
        
        Inventory = new List<Item>();
        Inventory.Add(defaultItem);
    }

    [JsonConstructor]
    public PlayerSavingData(int money, List<Item> inventory, int currentItemIndex)
    {
        Money = money;
        Inventory = new List<Item>(inventory);
        CurrentItemIndex = currentItemIndex;
    }

    public int Money { get; set; }
    public List<Item> Inventory { get; set; }
    public int CurrentItemIndex { get; set; }
}
