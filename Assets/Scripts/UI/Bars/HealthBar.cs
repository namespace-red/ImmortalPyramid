using System;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : SmoothBar
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        if (_health == null) throw new NullReferenceException(nameof(_health));
        Slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= SetValue;
    }
}