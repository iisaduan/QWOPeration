using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    /* Update() - once per frame
     *
     * Updates money text
     *
     */
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
        
    }
}
