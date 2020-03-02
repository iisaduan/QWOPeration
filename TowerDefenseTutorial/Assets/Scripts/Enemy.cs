
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Attributes")]

    public float speed = 10f;
    // public int startHealth = 100;
    public int health = 100;

    public int moneyGain = 50; 

    [Header("Unity Setup Fields")]
    public GameObject deathEffect;
    private Transform target;
    private int waypointIndex = 0;
    


    /* Start() - when game begins
     *
     * initializes waypoints 
     *
     */
    private void Start()
    {
        target = Waypoints.points[0];
    }

    /* Update() - every frame
     *
     * goes towards closest waypoint, switches waypoints when necessary
     * 
     */
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // if close the waypoint - go towards next waypoint
        if (Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint();
        }


    }

    /* TakeDamage(float damage)
     *
     * removes damage amount from health,
     *
     * if enemy has 0 health, it  dies
     *
     */
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
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

    /* GetNextWaypoint()
     *
     * sets target to next waypoint
     *
     * if no more waypoints, calls EndPath()
     *
     */
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    /* EndPath()
     *
     * decreaes player lives and destroys enemy game object
     *
     *
     */
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
