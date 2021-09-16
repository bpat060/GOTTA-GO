using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;    public GameObject exitMenuUI;    void Update()    {        if (Input.GetKeyDown(KeyCode.Escape))        {            if (GameIsPaused)            {                Resume();            }            else            {                Pause();            }        }    }    public void Resume()    {        exitMenuUI.SetActive(false);        Time.timeScale = 1F;        GameIsPaused = false;    }    public void Pause()    {        exitMenuUI.SetActive(true);        Time.timeScale = 0F;        GameIsPaused = true;    }    public void LoadMenu()    {        Time.timeScale = 1f;        SceneManager.LoadScene(0);    }
}
