using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public int winScoreThreshold = 5;

    public static LogicScript instance;

    private float missionTimer = 0f;
    private bool hasWon = false;
    private bool hasLost = false;

    public TMP_Text finalScoreText;
    public TMP_Text finalCoinsText;
    public float gameTime = 60f;
    private bool gameEnded = false; 
    public Text gameOverTitle;
    public int coinCount = 0;
    public int shieldRewardCoins = 10;


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        // إذا كان اللاعب قد خسر، لا نضيف نقاط
        if (hasLost) return;

        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        Debug.Log("Score increased. Current score: " + playerScore);


        // التحقق من الفوز
        if (playerScore >= winScoreThreshold && !hasWon)
        {
            WinGame();
        }
    }

    void Start()
    {
        Debug.Log("Game Started in Mode: " + GameModeManager.SelectedMode);
        Time.timeScale = 1f;

        if (GameModeManager.SelectedMode == GameMode.Easy)
            winScoreThreshold = 10;
        else if (GameModeManager.SelectedMode == GameMode.Hard)
            winScoreThreshold = 20;
            

        Debug.Log("Win Score Threshold: " + winScoreThreshold);
    }

    void Update()
    {
        // إذا خسر اللاعب، نتوقف
        if (hasLost) return;

        if (GameModeManager.SelectedMode == GameMode.Mission)
        {
            missionTimer += Time.deltaTime;

            if (missionTimer >= 20f && !hasWon)
            {
                WinGame();
            }
        }
        if (!gameEnded)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                WinGame();
            }
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenuScene");
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
{
    if (hasLost) return;

    hasWon = true;
    gameEnded = true;

    gameOverTitle.text = "You Win!";

    finalScoreText.text = "Pipes Passed: " + playerScore.ToString();
    finalCoinsText.text = "Coins Collected: " + CoinManager.instance.coins.ToString();

    gameOverScreen.SetActive(true);

    if (SoundManager.instance != null)
    {
        SoundManager.instance.PlayWin();
    }

    Time.timeScale = 0f;
}

public void gameOver()
{
    if (gameEnded || hasWon) return;

    gameEnded = true;
    hasLost = true;

    gameOverTitle.text = "Game Over";

    finalScoreText.text = "Pipes Passed: " + playerScore.ToString();
    finalCoinsText.text = "Coins Collected: " + CoinManager.instance.coins.ToString();

    gameOverScreen.SetActive(true);

    Time.timeScale = 0f;
}

    void Awake()
{
    instance = this;
}

public void addCoin()
{
    coinCount++;

    if (coinCount == shieldRewardCoins)
    {
        BirdScript bird = FindFirstObjectByType<BirdScript>();

        if (bird != null)
        {
            bird.ActivateShield();
        }
    }
}
}