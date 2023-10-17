using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemType ItemType { get; protected set; } = ItemType.Non;
}
