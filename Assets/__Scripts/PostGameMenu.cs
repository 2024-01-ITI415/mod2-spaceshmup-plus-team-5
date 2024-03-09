using UnityEngine;
using UnityEngine.UI;

public class PostGameMenu : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        // Load highscores from HighscoreManager
        HighscoreManager.instance.LoadHighscores();

        // Update the UI with highscores
        UpdateHighscoreUI();
    }

    void UpdateHighscoreUI()
    {
        string displayText = "Highscores:\n";

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
