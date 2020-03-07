
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    private Transform target;
    public float speed = 70f;

    public int damage = 50;

    public float explosionRadius = 0f;

    public Vector3 direction = new Vector3(0f, 0f, 0f);

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
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        float distanceThisFrame = speed * Time.deltaTime;

        Vector3 dir;

        // if bullet is a straight shooter
        if (direction != new Vector3(0f, 0f, 0f))
        {
            
            // if the bullet is close to enemy - shoot
            if (target.position.magnitude - transform.position.magnitude <= .000000000000000000000000000000000000000000000000000000000001f)
            {
                HitTarget();
                return;
            }
            
            dir = direction;
        }
        
        else
        { 
            dir = target.position - transform.position;
        }
        
            


        // if bullet will hit the target within this frame - hit the target
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
        
    }

    /* setDirection(Vector3 dir)
     *
     * sets start direction of bullet for straight shooting bullets
     *
     */
    public void SetDirection(Vector3 startPos, Vector3 targetPos)
    {
        direction = targetPos - startPos;
    }

    /* HitTarget()
     *
     * Creates impact effect, destroys bullet, destroys target/enemy
     * 
     */
    void HitTarget()
    {
        GameObject effectIns =  (GameObject) Instantiate(impactEffect, target.position, transform.rotation);
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

    /* Damage(Transform enemy)
     *
     * damages enemy - right now just destroys it
     *
     */
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
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
