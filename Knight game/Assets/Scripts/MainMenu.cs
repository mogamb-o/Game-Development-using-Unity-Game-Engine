using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for changing scenes
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //This command will load next scene in the queue by finding current index of scene and add it by 1
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); 
        Application.Quit();
    }

}
