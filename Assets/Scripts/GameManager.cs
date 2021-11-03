using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int highScore;
    public string highPlayer;


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

    private void Start()
    {
        LoadSaveData();
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void setHighScore(int score, string player)
    {
        if(score > highScore)
        {
            highScore = score;
            highPlayer = player;
        }
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "brickbreaker.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highPlayer = data.highPlayer;
            highScore = data.highScore;
        }
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.highPlayer = highPlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "brickbreaker.json", json);
    }

    [System.Serializable]
    class SaveData
    {
        public string highPlayer;
        public int highScore;
    }
}
