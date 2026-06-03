using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public PowerSystem powerSystem;
    public bool shieldActive = false;
    public float shieldTime = 5f;
    public GameObject shieldEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSettings.ApplySelectedMode();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        flapStrength = GameSettings.birdSpeed; 
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            //myRigidbody.linearVelocity = Vector2.up * 10;
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Pipe"))
    {
        if (shieldActive)
        {
            Debug.Log("Shield protected the bird! Power did not decrease.");
            return;
        }
        if (powerSystem != null)
        {
            powerSystem.DecreasePower();
        }
        if (powerSystem.power <= 0)
        {
            logic.gameOver();
        }
    }

    else if (collision.gameObject.CompareTag("Ground"))
    {
        birdIsAlive = false;
        SoundManager.instance.PlayHit();
        SoundManager.instance.PlayGameOver();
        logic.gameOver();
    }


}

    public void DieWithRotation()
{
    birdIsAlive = false;
    myRigidbody.constraints = RigidbodyConstraints2D.None;
    myRigidbody.angularVelocity = 300f;
    logic.gameOver();
}


public void ActivateShield()
{
    if (!shieldActive)
    {
        StartCoroutine(ShieldTimer());
    }
}

IEnumerator ShieldTimer()
{
    shieldActive = true;

    if (shieldEffect != null)
    {
        shieldEffect.SetActive(true);
    }

    Debug.Log("Shield Activated!");

    yield return new WaitForSeconds(shieldTime);

    shieldActive = false;

    if (shieldEffect != null)
    {
        shieldEffect.SetActive(false);
    }

    Debug.Log("Shield Ended!");
}





}
