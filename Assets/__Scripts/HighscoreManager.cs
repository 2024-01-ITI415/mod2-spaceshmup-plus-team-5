using UnityEngine;
using UnityEngine.UI;

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
        string displayText = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        highscoreText.text = displayText;
    }

    private void SaveHighscores()
    {
        // Save highscores
        for (int i = 0; i < highscores.Length; i++)
        {
            PlayerPrefs.SetInt($"HighScore{i}", highscores[i]);
        }
    }

    private void LoadHighscores()
    {
        // Load highscores
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = PlayerPrefs.GetInt($"HighScore{i}", 0);
        }
    }
}
