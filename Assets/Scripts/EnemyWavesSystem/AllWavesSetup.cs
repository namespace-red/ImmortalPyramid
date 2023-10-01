using System.Collections.Generic;

public class AllWavesSetup
{
    private readonly List<IWaveSetup> _waveSetups = new List<IWaveSetup>();

    public int WaveCount => _waveSetups.Count;
    
    public IWaveSetup Get(int waveNumber)
        => _waveSetups[waveNumber - 1];

    public void Add(IWaveSetup waveSetup)
        => _waveSetups.Add(waveSetup);
}
