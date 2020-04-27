
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    protected Transform target;
    public float speed = 70f;

    public int damage = 50;

    // public float explosionRadius = 0f;

    public float poison = 0f;

    [Header("Unity Setup Fields")]
    public GameObject impactEffect;


    /* Seek(Transform _target)
     *
     * sets a target for bullet 
     *
     */
    public void Seek(Transform _target)
    {
        target = _target;
    }

    /* Update() - done once per frame
     *
     * moves bullet in real time
     *
     * determines if bullet hits something - calls HitTarget() if so
     * 
     */
    public void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;

        Vector3 dir = target.position - transform.position;

        // if bullet will hit the target within this frame - hit the target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    /* HitTarget()
     *
     * Creates impact effect, destroys bullet, destroys target/enemy
     * 
     */
    virtual public void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, target.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (target.GetComponent<EnemyBlack>() == null)
        {
            Damage(target);
        }


        Destroy(gameObject);
    }



    /* Damage(Transform enemy)
     *
     * damages enemy - right now just destroys it
     *
     */
    public void Damage(Transform enemy)
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
