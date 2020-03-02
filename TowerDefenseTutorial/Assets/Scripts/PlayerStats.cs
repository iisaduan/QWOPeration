using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;

    public int startLives = 20;

    // TODO: add any other player attributes here

    /* Start() - called at beginning of game
     *
     * Instantiate player money and lives
     *
     */
    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
