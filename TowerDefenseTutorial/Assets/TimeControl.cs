using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    // keeps track of if game is halted
    public GameObject uiHalt;

    // keeps track of if game is sped up
    public GameObject uiDouble;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetFast();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetNormal();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHalt();
        }
    }

    // Halt time so players can place towers and strategize
    public void ToggleHalt()
    {
        ui.SetActive(!ui.activeSelf)
        if (uiHalt.activeSelf)
        {
            // freeze time while we are paused
            Time.timeScale = 0f;
        }
        else
        {
            // return to running game at previous speed
            UnHalt();
        }
    }

    // Continues running game at previous speed 
    public void UnHalt()
    {
        if (uiDouble.activeSelf)
        {
            Time.timescale = 2f;
        }
        else
        {
            Time.timescale = 1f;
        }
    }

    public void SetFast()
    {
        uiDouble.SetActive(true);
        if (!uiHalt.activeSelf)
        {
            Time.timescale = 1f;
        }
    }

    public void SetNormal()
    {
        uiDouble.SetActive(false);
        if (!uiHalt.activeSelf)
        {
            Time.timescale = 2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
