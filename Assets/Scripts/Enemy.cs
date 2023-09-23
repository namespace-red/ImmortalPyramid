using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public Health Health;

    public int RewardMoney { get; } = 1;
    
    private void Start()
    {
        Health = GetComponent<Health>();
    }
}
