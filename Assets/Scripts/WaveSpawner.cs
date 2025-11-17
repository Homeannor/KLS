using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemyFolder;

    public Transform spawnPoint;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI cashText;
    public Animator clearTextAnimator;
    public CurrencyUI currencyUI;

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;

    public int waveIndex = 0;
    private int enemiesLeftToSpawn = 0;
    private bool waveStarted = false;

    void Update()
    {
        if (countdown <= 0f)
        {
            int profitAmount = 50 * waveIndex;
            PlayerStats.Money += profitAmount;
            currencyUI.profitText(profitAmount);
            
            waveStarted = true;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        if (enemyFolder.childCount == 0 && waveStarted == true && enemiesLeftToSpawn == 0)
        {
            clearTextAnimator.SetTrigger("Flash");
            waveStarted = false;
            countdown = 3f;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        statusText.text = string.Format("WAVE " + waveIndex + " - {0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        enemiesLeftToSpawn = waveIndex;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy("Basic");
            enemiesLeftToSpawn--;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(string EnemyType)
    {
        if (EnemyType == "Basic")
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, enemyFolder);
        }
    }
}
