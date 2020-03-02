using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // TODO: add pausing and fastforwarding feature here probably?

    private bool gameEnded = false;

    /* Update() - called once per frame
     *
     * if player is out of lives, ends game
     *
     */
    void Update()
    {
        if(PlayerStats.Lives <= 0)
        {
            if(gameEnded)
            {
                return;
            }
            EndGame();
        }
    }

    /* EndGame()
     *
     * ends game - HAS NOFUNCTIONALITY YET
     *
     * TODO: make this do things
     * 
     */
    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");

    }

}
