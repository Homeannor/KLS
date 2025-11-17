using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int enemiesEliminated;
    public int startMoney = 400;

    void Start()
    {
        Money = startMoney;
        enemiesEliminated = 0;
    }
}
