using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PostGameMenu : MonoBehaviour
{
    public Text highscoreDisplayText;
    string displayText = "";

    void OnEnable()
    {
        if (HighscoreManager.instance != null)
        {
            HighscoreManager.instance.LoadHighscores();
            Debug.Log("enable called");
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
            // Initialize displayText as an empty string
            displayText = "";  // Clear the displayText before the loop

            for (int i = 0; i < 5; i++)
            {
                int score = HighscoreManager.instance.highscores[i];
                Debug.Log(score);
                displayText += $"{i + 1}. {score}\n";
                Debug.Log("Looped: " + i);
                Debug.Log("Looped: " + displayText);
                highscoreDisplayText.text += displayText + "\n";
            }

            // Append the entire displayText to highscoreDisplayText.text
            //highscoreDisplayText.text += displayText;

            // Update the highscoreDisplayText directly
            //highscoreDisplayText.text = displayText;

            // Check the updated text in the UI
            Debug.Log("Updated Highscores: " + displayText);
        }
        else
        {
            Debug.LogError("highscoreText is NULL in PostGameMenu.UpdateHighscoreUI()");
        }
        highscoreDisplayText.text = displayText;
    }
}
