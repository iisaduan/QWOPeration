using System.Collections;

using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;


    /* Start() - when game begins
     *
     * initializes waypoints 
     *
     */
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        if (enemy.path == Enemy.EnemyPath.Land)
        {
            target = Waypoints.groundPoints[0];
        }
        else
        {
            target = Waypoints.airPoints[0];
        }
    }

    /* Update() - every frame
     *
     * goes towards closest waypoint, switches waypoints when necessary
     * 
     */
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // if close the waypoint - go towards next waypoint
        if (Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint();
        }
        enemy.distanceTraveled = enemy.speed * Time.deltaTime;
        enemy.speed = enemy.startSpeed;
        

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
        // need to do this for both airPoints and groundPoints
        if (waypointIndex >= Waypoints.airPoints.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.airPoints[waypointIndex];
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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
