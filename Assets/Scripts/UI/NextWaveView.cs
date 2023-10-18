using System;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveView : MonoBehaviour
{
    [SerializeField] private WaveSystem _waveSystem;
    [SerializeField] private Button _nextWaveButton;
    
    private void Awake()
    {
        if (_waveSystem == null) throw new NullReferenceException(nameof(_waveSystem));
        if (_nextWaveButton == null) throw new NullReferenceException(nameof(_nextWaveButton));
    }

    private void OnEnable()
    {
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClicked);
        _waveSystem.SpawnedAllEnemiesInWave += ActivateButton;
    }

    private void OnDisable()
    {
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClicked);
        _waveSystem.SpawnedAllEnemiesInWave -= ActivateButton;
    }
    
    private void OnNextWaveButtonClicked()
    {
        _waveSystem.StartNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
    
    private void ActivateButton()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }
}
