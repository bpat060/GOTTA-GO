using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //calling a function to run the game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    //calling a function to run the tutorial
    public void PlayTutorial()
    {
        SceneManager.LoadScene(3);
    }
}
