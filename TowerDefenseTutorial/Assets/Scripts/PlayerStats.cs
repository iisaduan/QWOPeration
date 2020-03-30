 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;

    public int startLives = 20;

    public static int Rounds;

    // a dictionary storing the types and number of each type of enemies the player has killed
    public static Dictionary<string, int> enemiesKilled = new Dictionary<string, int>();

    // a dictionary storing the types of towers and number of each tower the player has built
    public static Dictionary<string, int> turretsBuilt = new Dictionary<string, int>();

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

        Rounds = 0;
    }
}
