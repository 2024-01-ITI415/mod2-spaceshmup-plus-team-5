using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager instance;

    public int[] highscores = new int[5]; // Top 5 highscores array.
    public Text highscoreText; 
    public GameObject postGameMenu;

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
        }
    }

    private void Start()
    {
        // Default list is scores of zero
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = 0;
        }

        UpdateHighscoreUI();
    }

    public void AddHighscore(int score)
    {
        // Update the highscores array
        for (int i = 0; i < highscores.Length; i++)
        {
            if (score > highscores[i])
            {
                // Insert the new score at the appropriate position
                for (int j = highscores.Length - 1; j > i; j--)
                {
                    highscores[j] = highscores[j - 1];
                }
                highscores[i] = score;
                break;
            }
        }

        UpdateHighscoreUI();
        Invoke("ShowPostGameMenuWithDelay", 2.0f);
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

    public void ShowPostGameMenuWithDelay()
    {
        SceneManager.LoadScene("PostGameMenuScene");
    }
}
