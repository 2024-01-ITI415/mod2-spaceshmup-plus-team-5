using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        UpdateHighscoreUI();
    }

    void UpdateHighscoreUI()
    {
        string displayText = "Highscores:\n";
        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt($"HighScore{i}", 0);
            displayText += $"{i + 1}. {score}\n";
        }

        highscoreText.text = displayText;
    }
}
