using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    static SaveManager instance = null;
    public static SaveManager Instance { get { return instance; } }
    private GameData gameData = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string GetFullFileName()
    {
        return Application.persistentDataPath + "/game.save";
    }

    public GameData GetGameData()
    {
        if(gameData == null)
        {
            gameData = new GameData();
        }
        return gameData;
    }

    public void SetGameData(GameData data)
    {
        gameData = data;
    }

    public void Save()
    {
        if(gameData != null)
        {
            string dataJoson = JsonUtility.ToJson(gameData, true);
            File.WriteAllText(GetFullFileName(), dataJoson);
        }
    }

    public void Load()
    {
        string FilePath = GetFullFileName();
        if (File.Exists(FilePath))
        {
            string dataJson = File.ReadAllText(FilePath);
            gameData = JsonUtility.FromJson<GameData>(dataJson);
        }
    }
}

// save data is stored in users -> appdata -> locallow -> default company -> 3d platformer -> game.save
