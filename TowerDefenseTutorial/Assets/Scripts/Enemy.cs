
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float startHealth = 2f;
    public float health = 2f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint(); 
        }

        
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

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
