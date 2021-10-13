using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    //calling a function to run the normal game
    public void PlayNormalGame()
    {
        SceneManager.LoadScene(4);
    }
    //calling a function to run the hard game
    public void PlayHardGame()
    {
        SceneManager.LoadScene(5);
    }
    //calling a function to run the main menu
    public void RunMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
