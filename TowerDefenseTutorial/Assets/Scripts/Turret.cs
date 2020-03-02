using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public bool straightShooter = false;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
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
            return;
        }
        // weird vector math to make the turret rotate towards the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // determines if/when to shoot
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

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
        if(bullet != null)
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
