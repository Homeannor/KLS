using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI cashText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        statusText.text = Mathf.Round(countdown).ToString();
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
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
