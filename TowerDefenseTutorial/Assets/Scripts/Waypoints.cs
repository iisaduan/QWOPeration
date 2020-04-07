
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour
{
    // I wanted to make these two appear in the inspector so that we could assign a value
    // to groundPoints and airPoints in unity, but I'm not sure how to do that...
    public static Transform[] groundPoints;
    public static Transform[] airPoints;

    /* Awake() - done right before game starts
     *
     * creates an array of all waypoints (used in Enemy)
     * 
     */
    private void Awake()
    {
        // this is duplicating code so obviously it's inefficient, I was thinking
        // if there is a way to create an array of the two different sets of waypoints
        // and then just do this for each set
        groundPoints = new Transform[transform.childCount];
        for (int i = 0; i < groundPoints.Length; i++)
        {
            groundPoints[i] = transform.GetChild(i);
        }
        airPoints = new Transform[transform.childCount];
        for (int i = 0; i < airPoints.Length; i++)
        {
            airPoints[i] = transform.GetChild(i);
        }
    }

}
