using UnityEngine;
using UnityEngine.UI;

public class PostGameMenu : MonoBehaviour
{
    public Text highscoreListText;

    void Start()
    {
        UpdateHighscoreListUI();
    }

    void UpdateHighscoreListUI()
    {
        string displayText = "Highscores:\n";
        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt($"HighScore{i}", 0);
            displayText += $"{i + 1}. {score}\n";
        }

        highscoreListText.text = displayText;
    }
}
