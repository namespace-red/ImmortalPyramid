using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LocalDataProvider : IDataProvider
{
    private readonly SavedFileData _playerFileData = new SavedFileData("PlayerSave", ".json");
    private readonly SavedFileData _wavesFileData = new SavedFileData("WavesSave", ".json");
    private readonly IPersistentData _persistentData;
    
    public LocalDataProvider(IPersistentData persistentData)
    {
        _persistentData = persistentData ?? throw new NullReferenceException(nameof(persistentData));
    }
    
    public void Save()
    {
        SaveData(_persistentData.PlayerData, _playerFileData);
        SaveData(_persistentData.WavesData, _wavesFileData);
        
        Debug.Log("Data Saved");
    }

    public void LoadOrInit()
    {
        if (TryLoadData(out PlayerSavingData playerSavingData, _playerFileData))
            Debug.Log("Player Data Loaded");
        else
            playerSavingData = new PlayerSavingData();

        if (TryLoadData(out WavesSavingData wavesSavingData, _wavesFileData))
            Debug.Log("Waves Data Loaded");
        else
            wavesSavingData = new WavesSavingData();
        
        _persistentData.PlayerData = playerSavingData;
        _persistentData.WavesData = wavesSavingData;
    }

    private void SaveData<T>(T data, SavedFileData fileData)
    {
        var jsonString = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Objects
        });
        
        File.WriteAllText(fileData.FullPath, jsonString);
    }

    private bool TryLoadData<T>(out T data, SavedFileData fileData)
    {
        if (fileData.IsExist() == false)
        {
            data = default;
            return false;
        }

        var jsonString = File.ReadAllText(fileData.FullPath);
        data = JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Objects
        });
        return true;
    }
    
    private readonly struct SavedFileData
    {
        private readonly string _name;
        private readonly string _extension;

        public SavedFileData(string name, string extension)
        {
            _name = name;
            _extension = extension;
        }
        
        public string FullPath => Path.Combine(SavePath, _name + _extension);
        public bool IsExist() => File.Exists(FullPath);
        
        private static string SavePath => Application.persistentDataPath;
    }
}
