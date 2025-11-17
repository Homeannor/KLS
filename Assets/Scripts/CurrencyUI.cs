using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public Animator profitTextAnimator;
    public Animator decreaseTextAnimator;
    public GameObject profitTextLabel;

    private int totalProfit;
    private int totalLosses;

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

    public void profitText(int amount)
    {
        /*GameObject newText = Instantiate(profitTextLabel, GameObject.Find("Canvas").transform);
        Destroy(newText.gameObject, 1f);*/

        if (amount > 0)
        {
            profitTextAnimator.SetTrigger("ProfitFlash");
            profitTextAnimator.gameObject.GetComponent<TextMeshProUGUI>().text = "+ $" + amount.ToString();

            totalProfit += amount;
        }
    }

    public void decreaseText(int amount)
    {
        if (amount > 0)
        {
            decreaseTextAnimator.SetTrigger("DecreaseFlash");
            decreaseTextAnimator.gameObject.GetComponent<TextMeshProUGUI>().text = "- $" + amount.ToString();

            totalLosses += amount;
        }
    }
}
