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

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;

    private int waveIndex = 0;
    private bool waveStarted = false;

    void Update()
    {
        if (countdown <= 0f)
        {
            waveStarted = true;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        if (enemyFolder.childCount == 0 && waveStarted == true)
        {
            waveStarted = false;
            countdown = 3f;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        statusText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy("Basic");
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
