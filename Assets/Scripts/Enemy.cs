using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    public int stealAmount = 10;

    private Transform target;
    private int wavepointIndex = 0;
    private bool isReturning = false;
    private CurrencyUI currencyUI;

    void Start()
    {
        target = Waypoints.points[0];
        currencyUI = FindAnyObjectByType<CurrencyUI>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (dir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
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

                PlayerStats.Money -= stealAmount;
                currencyUI.decreaseText(stealAmount);
                stealAmount *= 2;

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
