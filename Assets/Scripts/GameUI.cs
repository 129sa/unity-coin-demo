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

    public AudioSource audioSource;
    public AudioClip coinClip;
    public AudioClip hitClip;

    public void playCoin() { audioSource.PlayOneShot(coinClip); }
    public void playHit() { audioSource.PlayOneShot(hitClip); }

    void Awake() { Instance = this; }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            EndGame("时间到，失败", new Color(1f, 0.4f, 0.3f));
        }
        timeText.text = "时间：" + Mathf.CeilToInt(timeLeft);
    }

    public void AddCoin()
    {
        if (gameOver) return;
        playCoin();
        coins++;
        coinText.text = "金币：" + coins + "/" + totalCoins;

        if (coins >= totalCoins) EndGame("胜利！",new Color(0.2f,1f,0.4f));
    }

    public void Lose() { EndGame("失败", new Color(1f, 0.4f, 0.3f)); }

    void EndGame(string msg,Color color)
    {
        gameOver = true;
        resultPanel.SetActive(true);
        resultText.text = msg + "\n金币" + coins + "/" + totalCoins;
        resultText.color = color;
        Time.timeScale = 0f;                        // 暂停
        Cursor.lockState = CursorLockMode.None;     // 放开鼠标点按钮
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}