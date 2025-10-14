using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Day and Night Cycle
    public Light sun;
    private float dayDuration = 60f;
    private float timeOfDay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayNightCycle();
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
