using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class AllWavesSetup
{
    public AllWavesSetup()
    {
        WaveSetups = new List<IWaveSetup>();
    }

    [JsonConstructor]
    public AllWavesSetup(List<IWaveSetup> waveSetups)
    {
        WaveSetups = waveSetups;
    }

    public int WaveCount => WaveSetups.Count;
    public List<IWaveSetup> WaveSetups { get; }

    public IWaveSetup Get(int waveNumber)
    {
        if ((waveNumber < 1) || (waveNumber > WaveCount))
            throw new ArgumentOutOfRangeException(waveNumber.ToString());
        
        return WaveSetups[waveNumber - 1];
    }

    public void Add(IWaveSetup waveSetup)
        => WaveSetups.Add(waveSetup);
}
