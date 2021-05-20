using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Setting back the freezing time 
        GameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //for frezzing the time to null 
        GameIsPaused = true;
    
    }

    public void Loadmenu()
    {
        Time.timeScale = 1f; //Setting back the time to normal
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();  
    }
}
