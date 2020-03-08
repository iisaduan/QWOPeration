using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public bool straightShooter = false;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;
    

    /* Start()
     *
     * makes  target update twice every second
     *
     */
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    /* UpdateTarget()
     *
     * updates turret's target by finding the closest enemy in range
     *
     * TODO: look at this for changing which enemy the turret shoots at
     *
     */
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // find closest enemy - MODIFY THIS IF WANT TO CHANGE SHOOTING BEHAVIOR
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        // if  there is an enemy in range - set that to target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    /* Update() -  called once per frame
     *
     * makes turret rotate towards target
     *
     * determines when to shoot
     *
     */
    void Update()
    {
        // if  there is no target - do nothing
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    // turns off the laser once out of range
                    impactLight.enabled = false;
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        } else
        {
            // determines if/ when to shoot
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

            //
        }
    }

        void LockOnTarget()
    {
        // weird vector math to make the turret rotate towards the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;

        }
        // sets the first point on the line rendered as the firepoint
        lineRenderer.SetPosition(0, firePoint.position);

        // sets the second point on the line rendered as the enemy
        lineRenderer.SetPosition(1, target.position);


        Vector3 dir = firePoint.position - target.position;

        // sets the laser in the proper rotation and position
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        



    }
    /* Shoot()
     *
     * shoots a bullet towards target
     *
     */
    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
            
        }

        // TODO: fix this bug - this  lines doesn't work  for some reason
        /*
        if (straightShooter)
        {
            bullet.setDirection(bullet.transform.position, target.transform.position);
        }
        */
    }

    /* OnDrawGizmosSelected()
     *
     * shows range of turret using a red sphere
     * Only works in "create" mode 
     *
     * TODO: make this work in play mode
     *
     */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
