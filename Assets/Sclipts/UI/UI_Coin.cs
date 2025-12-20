using UnityEngine;
using UnityEngine.U2D.Animation;

public class UI_Coin : MonoBehaviour
{
    public static UI_Coin Instance;

    public SpriteResolver digit100;
    public SpriteResolver digit10;
    public SpriteResolver digit1;

    public int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCoin()
    {
        score++;
        UpdateDigits();
    }

    void UpdateDigits()
    {
        int ones = score % 10;
        int tens = (score / 10) % 10;
        int hundreds = (score / 100) % 10;

        digit1.SetCategoryAndLabel("OnesPlace", ones.ToString());
        digit10.SetCategoryAndLabel("TensPlace", tens.ToString());
        digit100.SetCategoryAndLabel("HandredsPlace", hundreds.ToString());

    }
}
