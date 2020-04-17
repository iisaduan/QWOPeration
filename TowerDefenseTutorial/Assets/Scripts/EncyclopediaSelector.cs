using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EncyclopediaSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject g;
    Turret t;
    public Text range;
    public Text damage;
    public Text fireRate;
    public Text explosionRadius;
    public Text damageOverTime;
    public Text slowRate;

    void Start()
    {
        t = g.GetComponent<Turret>();
        if (t.useLaser)
        {
            damageOverTime.text = "Damage Over Time: " + t.damageOverTime;
            slowRate.text = "Slow Rate: " + t.slowAmount;
        }
        else
        {
            range.text = "Range: " + t.range;
            damage.text = "Damage: " + t.bulletPrefab.GetComponent<Bullet>().damage;
            if (fireRate != null)
            {
                if (t.fireRate == 1)
                {
                    fireRate.text = "Fire Rate: " + t.fireRate + " bullet per second";

                }
                else
                {
                    fireRate.text = "Fire Rate: " + t.fireRate + " bullets per second";
                }
            }
            if (explosionRadius != null)
            {
                explosionRadius.text = "Explosion Radius: " + t.bulletPrefab.GetComponent<Bullet>().explosionRadius;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
