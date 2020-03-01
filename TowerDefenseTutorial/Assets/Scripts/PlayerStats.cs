using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    // TODO: add health and other player attributes here

    private void Start()
    {
        Money = startMoney;
    }
}
