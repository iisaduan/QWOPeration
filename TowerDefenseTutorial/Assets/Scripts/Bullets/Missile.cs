using UnityEngine;

public class Missile : Bullet
{
    public float explosionRadius = 0f;


    /* HitTarget()
     *
     * explodes, kills black enemies, and calls base's HitTarget
     *
     */
    override public void HitTarget()
    {       
        Explode();

        if(target.GetComponent<EnemyBlack>() != null)
        {
            base.Damage(target);
        }

        base.HitTarget();
    }


    /* Explode()
     *
     * creates explosion for missile launcher
     *
     */
    void Explode()
    {
        // finds all objects in explosionRadius, determines  which are enemies, and damages them
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }


    /* OnDrawGizmosSelected()
     *
     * shows range of turret using a red sphere
     * Only works in "create" mode
     * 
     */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
