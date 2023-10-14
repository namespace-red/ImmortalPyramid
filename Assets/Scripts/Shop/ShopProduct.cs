using UnityEngine;

public abstract class ShopProduct : ScriptableObject
{
    [field: SerializeField] public GameObject Model { get; private set; }
    [field: SerializeField] public string Label { get; private set; }
    [field: SerializeField, Min(0)] public int Price { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public bool IsBuyed { get; set; }
}
