using System.Collections;
using UnityEngine;

public class GoldTower : Turret
{
    public int goldPerSecond = 1;


    /* Start
     *
     * starts gold coroutine
     *
     */
    override public void Start()
    {
        StartCoroutine(Gold());
    }


    /* Update
     *
     * nothing to do here - simply overriding the base method by returning
     * 
     */
    override public void Update()
    {
        return;
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
