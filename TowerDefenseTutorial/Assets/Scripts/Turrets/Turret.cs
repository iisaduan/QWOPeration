﻿using UnityEngine;

public class Turret : MonoBehaviour
{

    protected Transform target;
    protected Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    public ShootType shootType = ShootType.Closest;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;


    /* Start()
     *
     * makes target update twice every second
     *
     */
    virtual public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);

    }


    /* UpdateTarget()
     *
     * updates turret's target by finding enemy in range according to shootType
     *
     */
    public void UpdateTarget()
    {
        // closest
        if (shootType == ShootType.Closest)
        {
            ShootClose();
        }

        // most heath
        else if (shootType == ShootType.MostHealth)
        {
            ShootMostHealth();
        }

        // first (closest to end)
        else if (shootType == ShootType.First)
        {
            ShootFirst();
        }

        // last (closest to start)
        else if (shootType == ShootType.Last)
        {
            ShootLast();
        }
    }


    /* ShootLast()
     *
     * sets target to be the last enemy in range (closest to beginning)
     *
     * TODO: make this work correctly (it currently shoots first enemy)
     *
     */
    void ShootLast()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        Enemy lastEnemy = null;
        float distanceToEnemy = Mathf.Infinity;

        // find closest enemy - MODIFY THIS IF WANT TO CHANGE SHOOTING BEHAVIOR
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyVar = enemy.GetComponent<Enemy>();
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyVar.distanceTraveled < shortestDistance && distance <= range)
            {
                shortestDistance = enemyVar.distanceTraveled;
                lastEnemy = enemyVar;
                distanceToEnemy = distance;
            }

        }

        // if  there is an enemy in range - set that to target
        if (lastEnemy != null && distanceToEnemy <= range)
        {
            target = lastEnemy.transform;
            targetEnemy = lastEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }


    /* ShootFirst()
     *
     * sets target to be the first enemy in range (closest to end)
     *
     */
    void ShootFirst()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = 0;
        Enemy firstEnemy = null;
        float distanceToEnemy = 0;

        // find closest enemy - MODIFY THIS IF WANT TO CHANGE SHOOTING BEHAVIOR
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyVar = enemy.GetComponent<Enemy>();
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyVar.distanceTraveled > shortestDistance && distance <= range)
            {
                shortestDistance = enemyVar.distanceTraveled;
                firstEnemy = enemyVar;
                distanceToEnemy = distance;
            }

        }

        // if  there is an enemy in range - set that to target
        if (firstEnemy != null && distanceToEnemy <= range)
        {
            target = firstEnemy.transform;
            targetEnemy = firstEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }


    /* ShootClose()
     *
     * sets target to be the closest enemy in range
     *
     */
    void ShootClose()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // find closest enemy 
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        // if there is an enemy in range - set that to target
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


    /* ShootMostHealth()
     *
     * sets target to be the enemy with the most health in range
     *
     */
    void ShootMostHealth()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float distance = Mathf.Infinity;
        Enemy mostHealthEnemy = null;
        float enemyHealth = 0;

        // find closest enemy - MODIFY THIS IF WANT TO CHANGE SHOOTING BEHAVIOR
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyVar = enemy.GetComponent<Enemy>();
            float distanceToEnemy = Vector3.Distance(transform.position, enemyVar.transform.position);
            if (enemyHealth < enemyVar.health && distanceToEnemy <= range)
            {
                mostHealthEnemy = enemyVar;
                enemyHealth = enemyVar.health;
                distance = distanceToEnemy;
            }

        }

        // if  there is an enemy in range - set that to target
        if (mostHealthEnemy != null && distance <= range)
        {
            target = mostHealthEnemy.transform;
            targetEnemy = mostHealthEnemy.GetComponent<Enemy>();
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
    virtual public void Update()
    {
        UpdateTarget();

        if (target != null)
        {
            LockOnTarget();
        }
    }


    /* LockOnTarget()
     *
     * positions turret so it is facing target
     *
     */
    public void LockOnTarget()
    {
        // weird vector math to make the turret rotate towards the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }


    /* OnDrawGizmosSelected()
     *
     * shows range of turret using a red sphere
     * Only works in "create" mode 
     *
     */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
