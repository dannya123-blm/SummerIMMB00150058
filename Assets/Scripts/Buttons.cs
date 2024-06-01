using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // This method will be called when any Start button is pressed for any of the scenes
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Level_1");
        SceneManager.LoadScene("Level_2");
        SceneManager.LoadScene("GameWon");
        SceneManager.LoadScene("GameOver");
    }
}
