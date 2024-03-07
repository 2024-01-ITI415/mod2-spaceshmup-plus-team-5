using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(OnrestartButtonClick);
    }

    private void OnrestartButtonClick()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
