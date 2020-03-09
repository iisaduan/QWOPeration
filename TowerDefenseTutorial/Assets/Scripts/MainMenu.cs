using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";

    /* Play()
     *
     * loads levelToLoad on screen
     *
     */
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    /* Quit()
     *
     * Quits out of application
     *
     * Note: this will not show up in inspector
     *
     */
    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
