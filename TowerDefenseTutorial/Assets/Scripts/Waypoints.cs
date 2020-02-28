
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    /* Awake() - done right before game starts
     *
     * creates an array of all waypoints (used in Enemy)
     * 
     */
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
