using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public HighScore highScore = null;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    public class HighScore
    {
        public string name;
        public int points;
    }

    public void SaveHighScore(int points)
    {
        HighScore newHighScore = new HighScore();
        newHighScore.name = playerName;
        newHighScore.points = points;

        // update current highscore before saving
        this.highScore = newHighScore;

        string json = JsonUtility.ToJson(newHighScore);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore highScore = JsonUtility.FromJson<HighScore>(json);

            this.highScore = highScore;
        }
    }
}
