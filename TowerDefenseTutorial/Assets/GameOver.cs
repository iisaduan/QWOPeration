  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    // onEnable is called whenever the GameOver object is enabled
    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    // Retry() reload the level
    public void ReTry()
    {
        //loads the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //Todo: create a menu
        Debug.Log("Go to Menu");
    }
}
