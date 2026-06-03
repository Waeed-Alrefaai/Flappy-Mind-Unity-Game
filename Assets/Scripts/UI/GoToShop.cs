

using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToShop : MonoBehaviour
{
    public void OpenShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
