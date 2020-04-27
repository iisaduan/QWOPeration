using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    /* FadeTo
     * 
     * transition to new scene
     * 
     */
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    /* FadeIn()
     *
     * fades from a scene to black
     * 
     */
    IEnumerator FadeIn()
    {
        // initiate the transparency level to 1
        float t = 1f;


        while (t > 0f)
        {
            // decrease the transparency level as time passes
            t -= Time.deltaTime;
            // convert the transparency level into alpha using the fading curve
            float alpha = curve.Evaluate(t);
            // set the image color to black with the alpha calculated from above
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }

    }


    /* FadeOut
     * 
     * Fade out from black
     */
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
