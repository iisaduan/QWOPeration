using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPink : Enemy
{
    public float slowHealthAmt = 0;

    // Start is called before the first frame update
    override public void TakeDamage(float damage, float poison)
    {
        base.speed += damage * slowHealthAmt;
        base.startSpeed = speed;
        //Debug.Log(base.speed);
        base.TakeDamage(damage, poison);
    }
}
