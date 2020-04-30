using UnityEngine;

public class PoisonBullet : Bullet
{

    public float poison = 30f;


    /* Damage(Transform enemy)
     *
     * damages enemy and poisons it
     *
     */
    override public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            if (e.GetComponent<EnemyPink>() != null)
            {
                e.GetComponent<EnemyPink>().TakeDamage(damage, poison);
            }
            else
            {
                e.TakeDamage(damage, poison);
            }
        }
    }
}
