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
        Debug.Log(Mathf.RoundToInt(scoreManager.timeScore));
        

        if(playerController.isSurvival == true)
        {
            UpdateDigits();
        }

    }

    void UpdateDigits()
    {
        int one = Mathf.RoundToInt(scoreManager.timeScore) % 10;
        int ten = Mathf.RoundToInt(scoreManager.timeScore) / 10;
        int hundred = Mathf.RoundToInt(scoreManager.timeScore) / 100;
        int thousand = Mathf.RoundToInt(scoreManager.timeScore) / 1000;
        int ten_thousand= Mathf.RoundToInt(scoreManager.timeScore) / 10000;
        int one_hundred_thousand = Mathf.RoundToInt(scoreManager.timeScore) / 100000;
        int million = Mathf.RoundToInt(scoreManager.timeScore) / 1000000;
        int ten_million = Mathf.RoundToInt(scoreManager.timeScore) / 10000000;
        int one_hundred_million = Mathf.RoundToInt(scoreManager.timeScore) / 100000000;

        sr1.SetCategoryAndLabel("1", one.ToString());
        sr10.SetCategoryAndLabel("10", ten.ToString());
        sr100.SetCategoryAndLabel("100", hundred.ToString());
        sr1000.SetCategoryAndLabel("1000", thousand.ToString());
        sr10000.SetCategoryAndLabel("10000", ten_thousand.ToString());
        sr100000.SetCategoryAndLabel("100000", one_hundred_thousand.ToString());
        sr1000000.SetCategoryAndLabel("1000000", million.ToString());
        sr10000000.SetCategoryAndLabel("10000000", ten_million.ToString());
        sr100000000.SetCategoryAndLabel("100000000", one_hundred_million.ToString());
    }
}
