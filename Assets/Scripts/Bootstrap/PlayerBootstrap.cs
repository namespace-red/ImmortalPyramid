using System;
using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private IPersistentData _persistentData;

    public void Init(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
        
        InitPlayer();
    }

    private void InitPlayer()
    {
        _player = _player ?? throw new NullReferenceException(nameof(_player));
        _player.Init(_persistentData);
    }
}
