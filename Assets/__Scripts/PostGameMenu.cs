using UnityEngine;
using UnityEngine.UI;

public class PostGameMenu : MonoBehaviour
{
    public Text highscoreDisplayText;
    string displayText = "";

    void OnEnable()
    {
        if (HighscoreManager.instance != null)
        {
            HighscoreManager.instance.LoadHighscores();
        }
        else
        {
            Debug.LogError("HighscoreManager.instance is NULL in PostGameMenu.OnEnable()");
        }

        // Update the UI with highscores
        UpdateHighscoreUI();
    }


    void UpdateHighscoreUI()
    {
        Debug.Log("UpdateHighscoreUI is being called.");

        if (highscoreDisplayText != null)
        {

            for (int i = 0; i < 5; i++)
            {
                int score = HighscoreManager.instance.highscores[i];
                displayText += $"{i + 1}. {score}\n";
            }

            // Print retrieved highscores for debugging
            Debug.Log("Retrieved Highscores: " + displayText);

            // Update the highscoreDisplayText directly
            highscoreDisplayText.text = displayText;

            // Check the updated text in the UI
            string highscoreTextAsString = highscoreDisplayText.text;
            Debug.Log(highscoreTextAsString);
        }
        else
        {
            Debug.LogError("highscoreText is NULL in PostGameMenu.UpdateHighscoreUI()");
        }
    }
}
