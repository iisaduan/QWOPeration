
using UnityEngine;
public class Enemy : MonoBehaviour
{

    [Header("Attributes")]

    public float startSpeed;
    [HideInInspector]
    public float speed = 10f;
    // public int startHealth = 100;
    public float health = 100;

    public int moneyGain = 50; 

    [Header("Unity Setup Fields")]
    public GameObject deathEffect;

    // Note: movement aspeccts of the enemy moved into EnemyMovement Script



    public void Start()
    {
        startSpeed = speed;
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

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);

    }

}
