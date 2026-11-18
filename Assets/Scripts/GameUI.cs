using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    public Text coinText;
    public Text timeText;
    public GameObject resultPanel;
    public Text resultText;

    public int totalCoins = 8;
    int coins = 0;
    float timeLeft = 45f;
    bool gameOver = false;

    void Awake() { Instance = this; }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            EndGame("时间到，失败");
        }
        timeText.text = "时间：" + Mathf.CeilToInt(timeLeft);
    }

    public void AddCoin()
    {
        if (gameOver) return;

        coins++;
        coinText.text = "金币：" + coins + "/" + totalCoins;

        if (coins >= totalCoins) EndGame("胜利！");
    }

    public void Lose() { EndGame("失败"); }

    void EndGame(string msg)
    {
        gameOver = true;
        resultPanel.SetActive(true);
        resultText.text = msg;

        Time.timeScale = 0f;                        // 暂停
        Cursor.lockState = CursorLockMode.None;     // 放开鼠标点按钮
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}