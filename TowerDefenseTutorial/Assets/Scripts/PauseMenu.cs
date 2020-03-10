using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;


    void Update()
    {
        // shows pause menu when user presses escape or P
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

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

    public void Retry()
    {
        // unfreeze time before loading new scene
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
