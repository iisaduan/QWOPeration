﻿using System.Collections;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        WaveSpawner.EnemiesAlive = 0; // set the number of alive enemies to zero to reset the wave spawner
        PlayerStats.enemiesKilled.Clear(); // reset the stat keeping track of the enemies killed
        PlayerStats.turretsBuilt.Clear(); // reset the stat keeping track of the towers built
    }

    public void Menu()
    {
        //Todo: create a menu
        Debug.Log("Go to Menu");
    }
}