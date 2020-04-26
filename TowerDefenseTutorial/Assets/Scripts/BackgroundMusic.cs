using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;

    private bool playing = true;

    private static BackgroundMusic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        string scene = SceneManager.GetActiveScene().name;
        AudioSource a = this.GetComponent<AudioSource>();
        if (scene == "Level1" || scene == "Level2" || scene == "Survival" || scene == "Tutorial" || scene == "testing" || scene == "MainScene")
        {
            if (playing)
            {
                a.Stop();
                playing = false;
            } 
        } else
        {
            if (!playing)
            {
                a.Play();
                playing = true;
            }
        }
    }
}
