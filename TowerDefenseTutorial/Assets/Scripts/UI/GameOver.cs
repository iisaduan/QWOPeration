using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFader sceneFader;


    /* Reset()
     *
     * resets the statistics once the game is over
     * 
     */
    public void Reset()
    {
        // set the number of alive enemies to zero to reset the wave spawner
        WaveSpawner.EnemiesAlive = 0;
        // reset the stat keeping track of the enemies killed
        PlayerStats.enemiesKilled.Clear();
        // reset the stat keeping track of the towers built
        PlayerStats.turretsBuilt.Clear(); 
    }

    /* Retry()
     * 
     * reloads the level
     * 
     */
    public void ReTry()
    {
        Reset();
        //loads the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /* Menu
     *
     * loads level select
     *
     */
    public void Menu()
    {
        Reset();
        SceneManager.LoadScene("LevelSelect");
    }
}
