using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : SmoothBar
{
    [SerializeField] private WaveSystem _waveSystem;

    private void Awake()
    {
        if (_waveSystem == null) throw new NullReferenceException(nameof(_waveSystem));
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
