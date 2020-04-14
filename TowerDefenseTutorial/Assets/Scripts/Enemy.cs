using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [Header("Attributes")]

    public float startSpeed;
    [HideInInspector]
    public float speed = 10f;
    public int startHealth = 100;
    public float health;

    public int moneyGain = 50;
    // used for turret shooting logic (first/last)
    public float distanceTraveled = 0;

    [Header("Unity Setup Fields")]
    public GameObject deathEffect;

    public Image healthBar;

    // Note: movement aspeccts of the enemy moved into EnemyMovement Script



    public void Start()
    {
        startSpeed = speed;
        health = startHealth;
    }



    /* TakeDamage(float damage)
     *
     * removes damage amount from health,
     *
     * if enemy has 0 health, it  dies
     *
     */
    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
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
     * enemy is destroyed, death effect happens
     *
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

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);

    }

}
