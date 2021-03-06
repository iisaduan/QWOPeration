﻿using UnityEngine;
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

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
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
