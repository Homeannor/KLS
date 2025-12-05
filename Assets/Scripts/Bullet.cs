using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float explosionRadius = 0f;
    public float speed = 70f;
    public float damage = 10f;
    private CurrencyUI currencyUI;
    public GameObject turretOrigin;

    //public AudioSource hitSound;

    public void Seek(Transform _target, GameObject origin)
    {
        target = _target;
        turretOrigin = origin;
    }

    void Start()
    {
        currencyUI = GameObject.Find("Shop Panel").GetComponent<CurrencyUI>();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        //hitSound.Play();
        target.GetComponent<Enemy>().takeDamage(damage);
        turretOrigin.GetComponent<Turret>().hitAmount++;
        Destroy(gameObject);
    }

    /*void Damage(Transform enemy)
    {
        PlayerStats.Money += enemy.gameObject.GetComponent<Enemy>().stealAmount;
        currencyUI.profitText(enemy.gameObject.GetComponent<Enemy>().stealAmount);
        PlayerStats.enemiesEliminated++;

        Destroy(enemy.gameObject);
    }*/
}
