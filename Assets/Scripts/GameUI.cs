using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;      // 全局唯一入口

    public Text coinText;               // 把 Text 拖进来
    int coins = 0;
    public Slider hpBar;
    public void SetHp(float ratio) { hpBar.value = ratio; }
    void Start()
    {
        SetHp(0.6f);
    }

    void Awake()
    {
        Instance = this;
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = "金币：" + coins;
    }
    public void OnClickAddCoin()
    {
        AddCoin();
    }
}