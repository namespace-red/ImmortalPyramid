using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class AbstractBar : MonoBehaviour
{
    [HideInInspector] protected Slider Slider;

    protected virtual void SetValue(float value, float maxValue)
        => Slider.value = value / maxValue;

    public void ClearValue()
        => Slider.value = 0;
}
