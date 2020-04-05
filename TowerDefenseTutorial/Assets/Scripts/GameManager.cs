using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // TODO: add pausing and fastforwarding feature here probably?

    public static bool gameIsOver;

    public static bool gameFinished;

    public GameObject gameOverUI;

    public GameObject winScreenUI;

    // Start method is called everytime we load a new scene, sets gameIsOver to false every time we start a new scene
    void Start()
    {
        gameIsOver = false;
        gameFinished = false;
    }

    /* Update() - called once per frame
     *
     * if player is out of lives, ends game
     *
     */
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (gameFinished)
        {
            if (WaveSpawner.EnemiesAlive == 0)
            {
                winScreenUI.SetActive(true);
            }
        }

    }

    /* EndGame()
     *
     * ends game
     * 
     */
    private void EndGame()
    {
        gameIsOver = true;

        gameOverUI.SetActive(true);

    }

}
