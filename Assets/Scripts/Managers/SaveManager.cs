using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SaveData<T>(string _fileName, T _dataToSave)
    {
        string savesFolderPath = Path.Combine(Application.persistentDataPath, "Saves");
        if (!Directory.Exists(savesFolderPath))
            Directory.CreateDirectory(savesFolderPath);

        string filePath = Path.Combine(savesFolderPath, _fileName);
        FileStream fileStream = null;
        try
        {
            //open file and modify it
            fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, _dataToSave);
        }
        finally
        {
            //close file
            fileStream?.Close();
        }
    }

    public static bool LoadData<T>(string _fileName, out T _dataToLoad)
    {
        _dataToLoad = default;
        string savesFolderPath = Path.Combine(Application.persistentDataPath, "Saves");
        if (!Directory.Exists(savesFolderPath))
            return false;

        string filePath = Path.Combine(savesFolderPath, _fileName);
        if (!File.Exists(filePath))
            return false;

        bool wasDataLoadSuccessful = false;
        FileStream fileStream = null;
        try
        {
            //open file and load it
            fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            _dataToLoad = (T)formatter.Deserialize(fileStream);
            wasDataLoadSuccessful = true;
        }
        finally
        {
            //close file
            fileStream?.Close();
        }

        return wasDataLoadSuccessful;
    }
}