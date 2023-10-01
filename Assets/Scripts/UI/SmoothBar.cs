using System.Collections;
using UnityEngine;

public class SmoothBar : AbstractBar
{
    private Coroutine _activeCoroutine;

    protected override void SetValue(float value, float maxValue)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        
        _activeCoroutine = StartCoroutine(ChangeHealthBarSmoothly(value, maxValue));
    }

    protected void SetValue(int value, int maxValue)
        => SetValue((float)value, (float)maxValue);
    
    private IEnumerator ChangeHealthBarSmoothly(float value, float maxValue)
    {
        var target = value / maxValue;
        
        while (Slider.value != target)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, target, Time.deltaTime);
            yield return null;
        }
    }
}
