using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    private bool isReturning = false;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (!isReturning)
        {
            if (wavepointIndex >= Waypoints.points.Length - 1)
            {
                isReturning = true;
                wavepointIndex--;
                target = Waypoints.points[wavepointIndex];
                return;
            }

            wavepointIndex++;
        }
        else
        {
            if (wavepointIndex <= 0)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex--;
        }

        target = Waypoints.points[wavepointIndex];
    }
}
