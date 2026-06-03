using UnityEngine;

public class Coin : MonoBehaviour
{

    
    public int Value = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ScoreManager.instance.AddScore(coinValue);
            CoinManager.instance.AddCoins(1);
            LogicScript.instance.addCoin();
            Destroy(gameObject);
        }
    }
    
}
