using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Enemy : MonoBehaviour
{

    [Header("Attributes")]

    public float startSpeed;
    [HideInInspector]
    public float speed = 10f;
    public int startHealth = 100;
    [HideInInspector]
    public float health;

    public int moneyGain = 50;
    // used for turret shooting logic (first/last)
    public float distanceTraveled = 0;

    public int spawnNumber = 0;

    public float slowHealthAmt = 0;

    public bool missileLauncher = false;

    private bool poisoned = false;

    private bool dead = false;

    [Header("Unity Setup Fields")]
    public GameObject deathEffect;

    public GameObject spawnPrefab;

    public Image healthBar;


    // Note: movement aspeccts of the enemy moved into EnemyMovement Script

    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
        
    }

    /* TakeDamage(float damage)
     *
     * removes damage amount from health,
     *
     * if enemy has 0 health, it  dies
     *
     */
    public void TakeDamage(float damage, float poison)
    {
        if (slowHealthAmt > 0f)
        {
            speed += damage * slowHealthAmt;
            startSpeed = speed;
        }
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !dead)
        {
            dead = true;
            Die();
        }

        if(!poisoned && poison > 0f)
        {
            StartCoroutine(Poison(this, poison));
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct); 
    }

    /* Die()
     *
     * Player gets more money
     *
     * enemy is destroyed, death effect happens, enemy gets counted in player statistics
     * of what types of enemies the player has defeated
     *
     */
    void Die()
    {
        PlayerStats.Money += moneyGain;

        // if the dictionary storing the enemies defeated does not have the type
        // of enemy that just died, add this type of enemy to the dictionary
        // with the number defeated being one
        if (!PlayerStats.enemiesKilled.ContainsKey(gameObject.transform.name))
        {
            PlayerStats.enemiesKilled.Add(gameObject.transform.name, 1);
        }
        else
        {
            // if the dictionary already contains the type of enemy that just died,
            // increment the count of defeated this type of enemies by one
            PlayerStats.enemiesKilled[gameObject.transform.name] += 1;
        }

        if(spawnNumber > 0)
        {
            StartCoroutine(SpawnMoreEnemies(this));

        }
        


        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        // helps with coroutine spawner
        Destroy(gameObject, (spawnNumber + 1) * .1f);
        this.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<EnemyMovement>().stop = true;

    }

    /* SpawnMoreEnemies()
     *
     * Spawns spawnNumber of enemies
     * 
     * TODO: distance enemies when spawned?
     *
     * TODO: make sure all stats and level complete stuff are good?
     *
     * TODO: make coroutine work somehow idk
     * 
     */
    static IEnumerator SpawnMoreEnemies(Enemy e)
    {

        for (int i = 0; i < e.spawnNumber; i++)
        {
            // spawn enemy
            GameObject spawned = Instantiate(e.spawnPrefab, e.transform.position, e.transform.rotation);
            // make sure spawned enemy heads to correct waypoint
            spawned.GetComponent<EnemyMovement>().SetWaypointIndex(e.GetComponent<EnemyMovement>().GetWaypointIndex());
            // update spawned enemies' distance
            spawned.GetComponent<Enemy>().distanceTraveled = e.distanceTraveled;
            // increase amount of enemies alive
            WaveSpawner.EnemiesAlive++;

            yield return new WaitForSeconds(.1f);
        }
    }

    

    public IEnumerator Poison(Enemy e, float poison)
    {
        // while enemy is alive
        while (e.health > 0f)
        {
            // decrease health and update UI
            health -= poison;
            healthBar.fillAmount = health / startHealth;
            // wait one second (slowly decreases health)
            yield return new WaitForSeconds(1f);
        }
        // one health is 0, die
        if (health <= 0)
        {
            Die();
        }
    }

}
