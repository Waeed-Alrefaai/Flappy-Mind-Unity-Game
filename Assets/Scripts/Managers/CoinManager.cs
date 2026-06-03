using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{

    public static CoinManager instance;

    public int coins = 0;
    public TMP_Text coinText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }

}
