using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataLocalProvider : IDataProvider
{
    private const string FileName = "PlayerSave";
    private const string SaveFileExtension = ".json";

    private IPersistentData _persistentData;

    public DataLocalProvider(IPersistentData persistentData)
        => _persistentData = persistentData;

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, FileName + SaveFileExtension);
    
    public void Save()
    {
        var jsonString = JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Objects
        });
        
        File.WriteAllText(FullPath, jsonString);
    }

    public bool TryLoad()
    {
        if (IsDataExist() == false)
            return false;

        var jsonString = File.ReadAllText(FullPath);
        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerSavingData>(jsonString);
        return true;
    }

    private bool IsDataExist()
        => File.Exists(FullPath);
}
