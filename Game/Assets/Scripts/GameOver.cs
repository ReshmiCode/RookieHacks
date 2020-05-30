using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
