using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int highScore;


    // Start is called before the first frame update
    private void Awake()
    {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void setHighScore(int score)
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "brickbreaker.json";
        if (File.Exists(path)
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "brickbreaker.json", json);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }
}
