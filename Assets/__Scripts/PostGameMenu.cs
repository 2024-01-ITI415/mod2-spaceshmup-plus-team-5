using UnityEngine;
using UnityEngine.UI;

public class PostGameMenu : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        Debug.Log($"HighScore0: {PlayerPrefs.GetInt("HighScore0", 0)}");
        Debug.Log($"HighScore1: {PlayerPrefs.GetInt("HighScore1", 0)}");
        // ... Repeat for HighScore2, HighScore3, HighScore4

        Invoke("UpdateHighscoreUI", 0.1f);
    }

    void UpdateHighscoreUI()
    {
        string displayText = "Highscores:\n";
        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt($"HighScore{i}", 0);
            displayText += $"{i + 1}. {score}\n";
        }

        // Print retrieved highscores for debugging
        Debug.Log("Retrieved Highscores: " + displayText);

        highscoreText.text = displayText;
    }
}
