using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : SmoothBar
{
    [SerializeField] private WaveSystem _waveSystem;

    private void Awake()
    {
        _waveSystem = _waveSystem ?? throw new NullReferenceException("ProgressBar._waveSystem can't be null");
        Slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _waveSystem.StartedWave += ClearValue;
        _waveSystem.SpawnedEnemy += SetValue;
    }

    private void OnDisable()
    {
        _waveSystem.StartedWave -= ClearValue;
        _waveSystem.SpawnedEnemy -= SetValue;
    }

}
