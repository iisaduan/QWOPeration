using UnityEngine.SceneManagement;
using UnityEngine;


/* Most of the code below comes from a YouTuber (everything except the Update() method)
 *
 * Title: 31 - Play Audio Through Multiple Scenes/Background in Unity3d
 * Author: LearnEverythingFast
 * Date: 6 Feb 2017
 * Availability: https://www.youtube.com/watch?v=i0coh71r-v8
 * 
 */

// Note: this code only works if start at MainMenu (or if you add this script to another scene
// and start there instead)

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;

    private bool playing = true;

    AudioSource a;

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
            a = this.GetComponent<AudioSource>();
        }
        // allows object to not be destroyed when scene changes
        DontDestroyOnLoad(this.gameObject);
    }

    /* Update()
     *
     * determines if music should be playing now or not and plays/stops it accordingly
     *
     * Note: this is the only part of the file that is original (not from above YouTube video)
     */
    public void Update()
    {
        string scene = SceneManager.GetActiveScene().name;
        // if scene is a playing scene (rather than level select, encyclopedia, etc)
        if (scene == "Level1" || scene == "Level2" || scene == "Survival" ||
            scene == "Tutorial" || scene == "testing" || scene == "MainScene")
        {
            // if music is playing in this scene - stop (bc other music will play)
            if (playing)
            {
                a.Stop();
                playing = false;
            } 
        } else
        {
            // of music is not playing in this scene - play it (bc this is 
            if (!playing)
            {
                a.Play();
                playing = true;
            }
        }
    }
}
