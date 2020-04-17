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
        speed.text = "Speed: " + e.startSpeed;
        health.text = "Health: " + e.startHealth;
        money.text = "Money Gained: " + e.moneyGain;
        
        
    }
}
