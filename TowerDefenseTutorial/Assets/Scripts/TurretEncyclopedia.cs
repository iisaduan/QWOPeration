using UnityEngine;
using UnityEngine.UI;


public class TurretEncyclopedia : MonoBehaviour
{

    public GameObject g;
    Turret t;
    public Text range;
    public Text damage;
    public Text fireRate;
    public Text explosionRadius;
    public Text damageOverTime;
    public Text slowRate;
    public Text poison;


    /* Start
     *
     * sets a bunch of text
     *
     */
    void Start()
    {
        t = g.GetComponent<Turret>();
        // if laser turret - set text accordingly 
        if (t.useLaser)
        {
            damageOverTime.text = "Damage Over Time: " + t.damageOverTime;
            slowRate.text = "Slow Rate: " + t.slowAmount;
            range.text = "Range: " + t.range;
        }
        else
        {
            range.text = "Range: " + t.range;
            damage.text = "Damage: " + t.bulletPrefab.GetComponent<Bullet>().damage;
            // sets fire rate
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
            // if missile launcher
            if (explosionRadius != null)
            {
                explosionRadius.text = "Explosion Radius: " + t.bulletPrefab.GetComponent<Bullet>().explosionRadius;
            }
            // if poison turret
            if (poison != null)
            {
                poison.text = "Poison rate: " + t.bulletPrefab.GetComponent<Bullet>().poison;
            }
        }
    }
}
