using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEncyclopedia : MonoBehaviour
{
    public GameObject g;
    Enemy e;
    public Text speed;
    public Text health;
    public Text money;
    public Text spawnType;

    void Start()
    {
        e = g.GetComponent<Enemy>();

        health.text = "Health: " + e.startHealth;
        money.text = "Money Gained: " + e.moneyGain;

        // if pink enemy display other speed info
        if(e.GetComponent<EnemyPink>() != null)
        {
            speed.text = "Start Speed: " + e.startSpeed;
            spawnType.text = "Speed increase amount: " + e.GetComponent<EnemyPink>().slowHealthAmt;
        } else
        {
            speed.text = "Speed: " + e.startSpeed;
        }

        
        
        
        
    }
}
