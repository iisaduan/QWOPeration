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
        LaserBeamer l = g.GetComponent<LaserBeamer>();
        if (l != null)
        {

            damageOverTime.text = "Damage Over Time: " + l.damageOverTime;
            slowRate.text = "Slow Rate: " + l.slowAmount;
            range.text = "Range: " + l.range;
        }
        else
        {
            StandardTurret s = g.GetComponent<StandardTurret>();
            range.text = "Range: " + s.range;
            damage.text = "Damage: " + s.bulletPrefab.GetComponent<Bullet>().damage;
            // sets fire rate
            if (fireRate != null)
            {
                if (s.fireRate == 1)
                {
                    fireRate.text = "Fire Rate: " + s.fireRate + " bullet per second";

                }
                else
                {
                    fireRate.text = "Fire Rate: " + s.fireRate + " bullets per second";
                }
            }
            // if missile launcher
            if (explosionRadius != null)
            {
                explosionRadius.text = "Explosion Radius: " + s.bulletPrefab.GetComponent<Missile>().explosionRadius;
            }
            // if poison turret
            if (poison != null)
            {
                poison.text = "Poison rate: " + s.bulletPrefab.GetComponent<PoisonBullet>().poison;
            }
        }
    }
}
