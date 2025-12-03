using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class UI_coingem : MonoBehaviour
{
    public static UI_coingem Instance;

    public SpriteResolver digit100;
    public SpriteResolver digit10;
    public SpriteResolver digit1;

    private int score = 0;
    private int score2 = 0;

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

    public void AddGem()
    {
        score2++;
        UpdateDigits2();
    }

    void UpdateDigits2()
    {
        int ones = score2 % 10;
        int tens = (score2 / 10) % 10;
        int hundreds = (score2 / 100) % 10;

        digit1.SetCategoryAndLabel("OnesPlace", ones.ToString());
        digit10.SetCategoryAndLabel("TensPlace", tens.ToString());
        digit100.SetCategoryAndLabel("HandredsPlace", hundreds.ToString());
    }
}
