using UnityEngine;
using UnityEngine.UI;

public class PowerSystem : MonoBehaviour
{
    public Slider powerBar;
    public float power = 100f;
    public float decreaseAmount = 5f;

    public LogicScript logic;

    void Start()
    {
        power = 100f;
        powerBar.maxValue = 100f;
        powerBar.value = power;
    }

    public void DecreasePower()
{
    BirdScript bird = FindFirstObjectByType<BirdScript>();

    if (bird != null && bird.shieldActive)
    {
        Debug.Log("Shield active: power did not decrease");
        return;
    }

    power -= decreaseAmount;

    if (power < 0)
    {
        power = 0;
    }

    powerBar.value = power;

    if (power <= 0)
    {
        bird.DieWithRotation();
    }
}

}
