
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
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
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        // if bullet will hit the target within this frame - hit the target
        if(dir.magnitude <= distanceThisFrame)
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
     * TODO: in here probably? make bullet decrease health instead of destroying it
     *
     */
    void HitTarget()
    {
        GameObject effectIns =  (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void  Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
