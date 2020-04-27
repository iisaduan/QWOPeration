
using UnityEngine;

// probably could be derived from EnemyMovement

[RequireComponent(typeof(EnemyPink))]
public class EnemyMovementPink : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private EnemyPink enemy;

    public bool stop;


    /* Start() - when game begins
     *
     * initializes waypoints 
     *
     */
    private void Start()
    {
        enemy = GetComponent<EnemyPink>();
        target = Waypoints.points[waypointIndex];
    }

    /* Update() - every frame
     *
     * goes towards closest waypoint, switches waypoints when necessary
     * 
     */
    private void Update()
    {
        if (stop)
        {
            return;
        }
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

    public void SetWaypointIndex(int waypoint)
    {
        waypointIndex = waypoint;
    }

    public int GetWaypointIndex()
    {
        return waypointIndex;
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
        if (waypointIndex >= Waypoints.points.Length - 1)
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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}

