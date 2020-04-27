using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;

    public static bool gameFinished;

    public GameObject gameOverUI;

    public GameObject winScreenUI;


    /* Start
     *
     * called ebery time a new scene is loaded
     * sets gameIsOver to false every time we start a new scene
     * 
     */
    void Start()
    {
        gameIsOver = false;
        gameFinished = false;
    }

    /* Update() - called once per frame
     *
     * if player is out of lives or player presses "e", ends game
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
