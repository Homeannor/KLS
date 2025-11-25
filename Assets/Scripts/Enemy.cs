using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float startSpeed = 10f;
    public float speed;
    public int stealAmount = 10;
    public float startHealth = 100f;
    public float health;

    public Image healthBar;

    private Transform target;
    private int wavepointIndex = 0;
    private bool isReturning = false;
    private CurrencyUI currencyUI;

    void Start()
    {
        target = Waypoints.points[0];
        currencyUI = FindAnyObjectByType<CurrencyUI>();

        health = startHealth;
        speed = startSpeed;
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Enemy health: " + health.ToString());

        float healthPercentage = health / startHealth;
        healthBar.fillAmount = healthPercentage;

        if (healthPercentage <= 0.25)
        {
            healthBar.color = Color.red;
        }
        else if (healthPercentage <= 0.5)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.green;
        }

        if (health <= 0)
        {
            PlayerStats.Money += stealAmount;
            currencyUI.profitText(stealAmount);
            PlayerStats.enemiesEliminated++;

            Debug.Log("Enemy Died!");
            Destroy(gameObject);
        }
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
