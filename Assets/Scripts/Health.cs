using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private float _value;
    
    public UnityAction<float, float> ValueChanged;
    public UnityAction Died;

    public float MinValue
    {
        get => _minValue;
        private set => _minValue = value;
    }

    public float MaxValue
    {
        get => _maxValue;
        private set => _maxValue = value;
    }

    public float Value
    {
        get => _value;
        private set
        {
            _value = Mathf.Clamp(value, _minValue , _maxValue);
            ValueChanged?.Invoke(Value, _maxValue);
            
            if (Value == 0)
                Died?.Invoke();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();
        
        Value -= damage;
    }

    public void Healing(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();
        
        Value += value;
    }
}
