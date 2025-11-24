using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.Mathematics;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform slowPrefab;
    public Transform fastPrefab;
    public Transform deyuraPrefab;
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

        if (waveIndex < 30)
        {
            statusText.text = string.Format("WAVE " + waveIndex + " - {0:00.00}", countdown);
        }
        else
        {
            statusText.text = "THE FINAL WAVE.";
            statusText.color = Color.red;
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        if (waveIndex <= 5)
        {
            enemiesLeftToSpawn = waveIndex;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy("Basic");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveIndex < 10)
        {
            enemiesLeftToSpawn = waveIndex + (waveIndex - 5);

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy("Basic");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }

            for (int i = 0; i < (waveIndex - 5); i++)
            {
                SpawnEnemy("Fast");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveIndex < 20)
        {
            enemiesLeftToSpawn = waveIndex + (waveIndex - 5) + (waveIndex - 10);

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy("Basic");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }

            for (int i = 0; i < (waveIndex - 5); i++)
            {
                SpawnEnemy("Fast");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }

            for (int i = 0; i < (waveIndex - 10); i++)
            {
                SpawnEnemy("Slow");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveIndex < 30)
        {
            enemiesLeftToSpawn = 999999999;

            while (true)
            {
                SpawnEnemy("Deyura");

                enemiesLeftToSpawn--;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void SpawnEnemy(string EnemyType)
    {
        if (EnemyType == "Basic")
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, enemyFolder);
        }
        else if (EnemyType == "Slow")
        {
            Instantiate(slowPrefab, spawnPoint.position, spawnPoint.rotation, enemyFolder);
        }
        else if (EnemyType == "Fast")
        {
            Instantiate(fastPrefab, spawnPoint.position, spawnPoint.rotation, enemyFolder);
        }
        else if (EnemyType == "Deyura")
        {
            Instantiate(deyuraPrefab, spawnPoint.position, spawnPoint.rotation, enemyFolder);
        }
    }
}
