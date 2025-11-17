using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Day and Night Cycle
    public Light sun;
    private float dayDuration = 60f;
    private float timeOfDay;

    private bool gameEnded = false;

    public CurrencyUI currencyUI;
    public WaveSpawner waveSpawner;

    public GameObject gameOverUI;
    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI enemyElimText;
    public TextMeshProUGUI totalProfitText;
    public TextMeshProUGUI totalLossText;
    public GameObject mainUI;
    public GameObject pauseUI;

    private bool isPaused;

    void Start()
    {
        Time.timeScale = 1;

        // Add more game logic when the time comes
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) { return; }

        if (PlayerStats.Money <= 0)
        {
            EndGame();
        }

        DayNightCycle();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            pauseGame();
        }
    }

    void pauseGame()
    {
        isPaused = !isPaused;

        pauseUI.SetActive(isPaused);
        mainUI.SetActive(!isPaused);

        Time.timeScale = isPaused ? 0 : 1;
    }

    void EndGame()
    {
        gameEnded = true;
        mainUI.SetActive(false);

        gameOverUI.SetActive(true);

        waveCountText.text = "WAVES SURVIVED: " + waveSpawner.waveIndex.ToString();
        enemyElimText.text = "ENEMIES ELIMINATED: " + PlayerStats.enemiesEliminated.ToString();
        totalProfitText.text = "PROFITS: $" + currencyUI.totalProfit.ToString();
        totalLossText.text = "LOSSES: $" + currencyUI.totalLosses.ToString();

        Time.timeScale = 0;
    }

    void DayNightCycle()
    {
        timeOfDay += Time.deltaTime;

        float angle = (timeOfDay / dayDuration) * 360f;
        float t = Mathf.Sin(timeOfDay / dayDuration * Mathf.PI * 2f) * 0.5f * 0.5f;

        sun.transform.rotation = Quaternion.Euler(angle - 90, 170, 0f);
        // sun.color = Color.Lerp(Color.black, Color.yellow, t);
    }
}
