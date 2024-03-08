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

        // Load highscores from HighscoreManager
        HighscoreManager.instance.LoadHighscores();

        // Retrieve the current highscore from PlayerPrefs
        int currentHighscore = PlayerPrefs.GetInt("CurrentHighscore", 0);

        // Display the current highscore or use it as needed
        Debug.Log($"Current Highscore: {currentHighscore}");

        // Update the UI with highscores
        UpdateHighscoreUI();

    }

    void UpdateHighscoreUI()
    {
        string displayText = "Highscores:\n" + Main.highScore;

        for (int i = 0; i < 5; i++)
        {
            int score = HighscoreManager.instance.highscores[i];
            displayText += $"{i + 1}. {score}\n";
        }

        // Print retrieved highscores for debugging
        Debug.Log("Retrieved Highscores: " + displayText);

        highscoreText.text = displayText;

    }
}