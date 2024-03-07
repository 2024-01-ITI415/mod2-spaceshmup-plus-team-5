using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}