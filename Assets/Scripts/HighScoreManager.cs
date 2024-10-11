using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using static MainManager;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreTexts; // Assign in the inspector

    private void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        SaveData data = LoadGameRank();

        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            if (i < data.HighScores.Count)
            {
                highScoreTexts[i].text = $"Best Score : {data.HighScores[i].PlayerName} : {data.HighScores[i].Score}";
            }
            else
            {
                highScoreTexts[i].text = $"Best Score :"; // Empty slot
            }
        }
    }

    private SaveData LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        SaveData data = new SaveData();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }

        return data;
    }
}
