using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private float turnSpeed = 10f;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoint.points[0];
    }

     void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;

    }
 
    void GetNextWayPoint()
    {
        LockWayPoints();
        if (wavepointIndex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }


    void LockWayPoints()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(enemy.rotatingGobs.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        enemy.rotatingGobs.rotation = Quaternion.Euler (0f,rotation.y, 0f);
    
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
