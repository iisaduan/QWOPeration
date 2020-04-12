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


    public void NextClick()
    {

        if (popUpIndex < popUps.Length - 1)
        {
            popUps[popUpIndex].SetActive(false);
            
            popUpIndex += 1;
            popUps[popUpIndex].SetActive(true);
            Debug.Log(popUpIndex);
        } if (popUpIndex == popUps.Length - 1)
        {
            next.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            endTutorial = true;

        }

    }

    public void MainClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
