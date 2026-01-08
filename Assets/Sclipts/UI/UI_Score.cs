using UnityEngine;
using UnityEngine.U2D.Animation;

public class UI_Score : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PlayerController playerController;

    public SpriteResolver sr1;
    public SpriteResolver sr10;
    public SpriteResolver sr100;
    public SpriteResolver sr1000;
    public SpriteResolver sr10000;
    public SpriteResolver sr100000;
    public SpriteResolver sr1000000;
    public SpriteResolver sr10000000;
    public SpriteResolver sr100000000;


    void Update()
    {
        Debug.Log(scoreManager.gameScore);
        

        if(playerController.isSurvival == true)
        {
            UpdateDigits();
        }

    }

    void UpdateDigits()
    {
        int one = scoreManager.gameScore % 10;
        int ten = scoreManager.gameScore / 10;
        int hundred = scoreManager.gameScore / 100;
        int thousand = scoreManager.gameScore / 1000;
        int ten_thousand= scoreManager.gameScore / 10000;
        int one_hundred_thousand = scoreManager.gameScore / 100000;
        int million = scoreManager.gameScore / 1000000;
        int ten_million = scoreManager.gameScore / 10000000;
        int one_hundred_million = scoreManager.gameScore / 100000000;

        sr1.SetCategoryAndLabel("1", one.ToString());
        sr10.SetCategoryAndLabel("10", ten.ToString());
        sr100.SetCategoryAndLabel("100", hundred.ToString());
        sr1000.SetCategoryAndLabel("1000", thousand.ToString());
        sr10000.SetCategoryAndLabel("10000", ten_thousand.ToString());
    }
}
