using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ResetButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void ResetGame()
    {
        // Add any logic you need before resetting the game
        Debug.Log("Game Reset!");
        SceneManager.LoadScene("_Scene_0");
    }
}