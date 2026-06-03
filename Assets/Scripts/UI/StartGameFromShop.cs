using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameFromShop : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}


