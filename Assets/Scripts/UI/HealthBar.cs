using System;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : SmoothBar
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health = _health ?? throw new NullReferenceException("HeathBar._health can't be null");
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