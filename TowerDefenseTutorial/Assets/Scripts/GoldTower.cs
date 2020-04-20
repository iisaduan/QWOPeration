using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTower : MonoBehaviour
{

    public int goldPerSecond = 1;

    public void Start()
    {
        StartCoroutine(Gold());
    }

    IEnumerator Gold()
    {
        while (true)
        {
            PlayerStats.Money += goldPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }

}
