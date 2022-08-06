using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string playerName, highName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class HighScoreData
    {
        public string highScoreName;
        public int score;
    }

    public void SaveScore(int playerScore)
    {
        highName = playerName;
        highScore = playerScore;
        HighScoreData data = new HighScoreData();
        data.highScoreName = playerName;
        data.score = playerScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            Debug.Log("High score data loaded from " + Application.persistentDataPath + "highscore.json");
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            highName = data.highScoreName;
            highScore = data.score;
        }
        else
        {
            Debug.Log("Could not load file highscore.json");
            highName = "Nobody";
            highScore = 0;
        }
    }
}
