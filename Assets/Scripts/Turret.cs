using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Unity Setup")]

    private string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public float hitAmount = 0f;
    public float upgradeAmount = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public Image cooldownBar;
    public GameObject cannonCanvas;
    public GameObject abilityCanvas;
    public Image abilityBar;
    public GameObject abilityAura;
    private bool upgraded;

    public AudioSource shootSound;
    public AudioSource upgradeSound;

    void Start()
    {
        upgraded = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        abilityCanvas.SetActive(true);
        abilityAura.SetActive(false);
        hitAmount = 0f;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void cooldownUI()
    {
        if (fireCooldown > 0)
        {
            cannonCanvas.SetActive(true);
            
            fireCooldown -= Time.deltaTime;

            float cooldownPerentage = fireCooldown / fireRate;
            cooldownBar.fillAmount = cooldownPerentage;
        }
        else
        {
            cannonCanvas.SetActive(false);
        }
    }

    void turretTargeting()
    {
        if (target == null) { return; }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void turretShooting()
    {
        if (target == null) { return; }

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void upgradeProgress()
    {
        if (hitAmount >= upgradeAmount && upgraded == false)
        {
            upgraded = true;

            upgradeSound.Play();
            abilityCanvas.SetActive(false);
            abilityAura.SetActive(true);
            fireRate /= 2;
        }
        else
        {
            float abilityPercentage = hitAmount / upgradeAmount;
            abilityBar.fillAmount = abilityPercentage;
        }
    }

    void Update()
    {
        cooldownUI();
        turretTargeting();
        turretShooting();
        upgradeProgress();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        shootSound.Play();
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (upgraded == true)
        {
            bullet.damage *= 2;
            bullet.speed *= 2;
        }

        if (bullet != null)
        {
            bullet.Seek(target, gameObject);
        }
    }
}
