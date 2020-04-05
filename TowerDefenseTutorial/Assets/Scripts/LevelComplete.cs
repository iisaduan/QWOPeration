using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{


    /*
    * Reset() resets the statistics once the game is over
    */
    public void Reset()
    {
        WaveSpawner.EnemiesAlive = 0; // set the number of alive enemies to zero to reset the wave spawner
        PlayerStats.enemiesKilled.Clear(); // reset the stat keeping track of the enemies killed
        PlayerStats.turretsBuilt.Clear(); // reset the stat keeping track of the towers built
    }

    // Retry() reloads the level
    public void Retry()
    {
        Reset();
        //loads the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Reset();
        SceneManager.LoadScene("MainMenu");
    }

    /*
    * NextLevel() loads the next level of the game
    */
    public void NextLevel()
    {
        Reset();
        // build index should be configured so that the next level will be at an
        // index above the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
