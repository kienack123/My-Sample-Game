using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadUtility
{
    private static SaveLoadUtility _instance;
    
    public static SaveLoadUtility Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveLoadUtility();
            }
            return _instance;
        }
    }
    private static string Save_File = "PlayerData.json";
    private static string File_Path = Path.Combine(Application.persistentDataPath, Save_File);
    
    
    private SavePlayerData playerData = new SavePlayerData();
    

    public SavePlayerData GetData()
    {
        return playerData;
    }
    
    public void LoadData()
    {
        if (!File.Exists(File_Path))
        {
            File.WriteAllText(File_Path, "");
            SaveData(playerData);
        }
        playerData = JsonUtility.FromJson<SavePlayerData>(File.ReadAllText(File_Path));
    }
    
    private void SaveData(SavePlayerData saveData)
    {

        if (!File.Exists(File_Path))
        {
            File.WriteAllText(File_Path, "");
        }

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(File_Path, json);

        Debug.Log("Saved");

        Debug.Log(File_Path);
    }

    public void ClearData()
    {
        SaveData(playerData);
        LoadData();
    }

}

[System.Serializable]
public class SavePlayerData
{
    public int Id;
    public string Name;
    public int Level;
    public int Type;
}

