
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Attributes")]

    public float speed = 10f;
    public float startHealth = 2f;
    public float health = 2f;

    [Header("Unity Setup Fields")]
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
        if(Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint(); 
        }

        
    }

    /* TakeDamage(float damage)
     *
     * removes damage amount from health
     *
     * TODO: this is used nowhere yet lol idk how to make it work
     *
     */
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    /* GetNextWaypoint()
     *
     * sets target to next waypoint, if no more waypoints destroy enemy
     * 
     * TODO: take damage from user if enemy gets to end
     */
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
