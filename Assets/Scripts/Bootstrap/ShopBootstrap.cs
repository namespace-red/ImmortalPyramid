using System;
using UnityEngine;

public class ShopBootstrap : MonoBehaviour
{
    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    public void Init(IDataProvider dataProvider, IPersistentData persistentData)
    {
        _dataProvider = dataProvider ?? throw new NullReferenceException(nameof(dataProvider));
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
    }
}
