using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager instance;

    public int[] highscores = new int[5]; // Top 5 highscores
    public Text highscoreText;

    private void Start()
    {
        // Load highscores first
        LoadHighscores();

        UpdateHighscoreUI();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log("HighscoreManager Awake: " + (instance != null ? "Instance set" : "Instance is NULL"));


        // Initialize highscores on startup
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = PlayerPrefs.GetInt($"HighScore{i}", 0);
        }

        UpdateHighscoreUI();
    }

    public void AddHighscore(int score)
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            if (score > highscores[i])
            {
                for (int j = highscores.Length - 1; j > i; j--)
                {
                    highscores[j] = highscores[j - 1];
                }
                highscores[i] = score;

                // Print highscores for debugging
                Debug.Log("Updated Highscores: " + string.Join(", ", highscores));

                break;
            }
        }

        UpdateHighscoreUI();
        SaveHighscores();
    }

    public int GetLowestHighscore()
    {
        if (highscores.Length > 0)
        {
            return highscores[highscores.Length - 1];
        }
        return 0;
    }

    private void UpdateHighscoreUI()
    {
        string displayText = "Highscore: " + highscores[0];
        highscoreText.text = displayText;
    }

    private void SaveHighscores()
    {
        // Save highscores
        for (int i = 0; i < highscores.Length; i++)
        {
            PlayerPrefs.SetInt($"HighScore{i}", highscores[i]);
        }
        PlayerPrefs.Save(); // Save changes
    }

    public void LoadHighscores()
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = PlayerPrefs.GetInt($"HighScore{i}", 0);
        }

        // Print loaded highscores for debugging
        Debug.Log("Loaded Highscores: " + string.Join(", ", highscores));
    }
}
