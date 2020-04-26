using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;

    /* Update
     *
     * toggles pause menu when user presses escape or P
     *
     */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    /* Toggle()
     *
     * toggles pause menu (if paused, unpauses, and vice versa)
     *
     */
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            // freeze time while we are paused
            Time.timeScale = 0f;
        } else
        {
            // return to running game normally
            Time.timeScale = 1f;
        }
    }

   /* Reset()
    *
    * resets the statistics if the player wishes to end the game
    * 
    */
    public void Reset()
    {
        Toggle(); // unfreeze time before loading new scene
        WaveSpawner.EnemiesAlive = 0; // set the number of alive enemies to zero to reset the wave spawner
        PlayerStats.enemiesKilled.Clear(); // reset the stat keeping track of the enemies killed
        PlayerStats.turretsBuilt.Clear(); // reset the stat keeping track of the towers built
    }

    /* Retry()
     *
     * level restarts
     *
     */
    public void Retry()
    {
        Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        WaveSpawner.EnemiesAlive = 0; // set the number of alive enemies to zero to reset the wave spawner
        PlayerStats.enemiesKilled.Clear(); // reset the stat keeping track of the enemies killed
        PlayerStats.turretsBuilt.Clear(); // reset the stat keeping track of the towers built
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
