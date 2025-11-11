using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Money >= 100)
        {
            moneyText.color = Color.yellow;
        }
        else
        {
            moneyText.color = Color.red;
        }

        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
