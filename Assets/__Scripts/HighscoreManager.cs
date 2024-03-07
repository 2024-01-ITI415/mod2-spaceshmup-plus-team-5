using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager instance;

    public int[] highscores = new int[5]; // Top 5 highscores
    public Text highscoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Create empty highscore slots of zeroes
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = 0;
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
        string displayText = "Highscores:\n";
        for (int i = 0; i < highscores.Length; i++)
        {
            displayText += $"{i + 1}. {highscores[i]}\n";
        }
        highscoreText.text = displayText;
    }

    private void SaveHighscores()
    {
        // Save highscores
    }

    private void LoadHighscores()
    {
        // Load highscores
    }
}
