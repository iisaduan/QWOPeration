  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFader sceneFader;

    // Retry() reload the level
    public void ReTry()
    {
        //loads the currently active scene
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        //Todo: create a menu
        Debug.Log("Go to Menu");
    }
}
