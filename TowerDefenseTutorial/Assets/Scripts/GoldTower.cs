using System.Collections;
using UnityEngine;

public class GoldTower : MonoBehaviour
{
    public int goldPerSecond = 1;

    /* Start
     *
     * starts gold coroutine
     *
     */
    public void Start()
    {
        StartCoroutine(Gold());
    }

    /* Gold
     *
     * increases player's money by goldPerSecond every second
     *
     */
    IEnumerator Gold()
    {
        while (true)
        {
            PlayerStats.Money += goldPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }

}
