using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;

    private int popUpIndex = 0;

    public Button next;

    public Button mainMenu;

    private bool endTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        next.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        endTutorial = false;
        popUps[0].SetActive(true);
        popUpIndex = 0;

    }

    /* NextClick()
     *
     * Makes tutorial move to next game object
     *
     */
    public void NextClick()
    {
        // if there is another  element in the list
        if (popUpIndex < popUps.Length - 1)
        {
            // set old popUp to not active
            popUps[popUpIndex].SetActive(false);
            
            popUpIndex += 1;
            // set new popUp to active
            popUps[popUpIndex].SetActive(true);
            Debug.Log(popUpIndex);


        }
        // if this is the last element
        if (popUpIndex == popUps.Length - 1)
        {
            // display main menu button instead of next button
            next.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            endTutorial = true;

        }

    }

    public void MainClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
