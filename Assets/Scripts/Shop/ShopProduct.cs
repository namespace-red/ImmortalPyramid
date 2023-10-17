using UnityEngine;

public class ShopProduct : ScriptableObject
{
    [field: SerializeField] public string Label { get; private set; }
    [field: SerializeField, Min(0)] public int Price { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public bool IsBought { get; set; }
    [field: SerializeField] public ItemType Type { get; private set; }
}
