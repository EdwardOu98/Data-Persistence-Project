using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string recordKeeper;
        public int highScore;
    }

    public static ScoreManager Instance;

    public string username;

    public string recordKeeper;

    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        string filePath = Application.persistentDataPath + "/highScore.json";
        SaveData data = new SaveData();

        data.recordKeeper = username;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public void LoadScore()
    {
        string filePath = Application.persistentDataPath + "/highScore.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordKeeper = data.recordKeeper;
            highScore = data.highScore;
        }
    }

    public void SetUsername(string Username)
    {
        username = Username;
    }

    public void UpdateRecord(int score)
    {
        recordKeeper = username;
        highScore = score;
        SaveScore();
    }
}
