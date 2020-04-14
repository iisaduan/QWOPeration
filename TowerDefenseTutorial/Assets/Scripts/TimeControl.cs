
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float timeFactor = 1f;
    
    // keeps track of if game is halted
    public GameObject uiHalt;

    // keeps track of if game is sped up
    public GameObject uiDouble;

    void Start()
    {

    }

    // called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            ChangeTime(1f + timeFactor);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G");
            ChangeTime(1f);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("H");
            ChangeTime(0f);
        }
    }

    void ChangeTime(float newTime)
    {
        // set maximum speed up to 10x,
        timeFactor = Mathf.Clamp(newTime, 0f, 10f);
        Time.timeScale = timeFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}

