using System.Data;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float timeScore = 0;

    public UI_Coin coin;
    public UI_Gem gem;
    public SpawnItems judge;
    public PlayerController playerController;
    public int gameScore = 0;
    public int coinScore;
    public int gemScore;


    void Start()
    {
        
    }

    void Update()
    {
        if (judge.gameNow == true)
        {
            timeScore += Time.deltaTime;
            Debug.Log(timeScore);
        }
        if(playerController.isSurvival==true)
        {
            ScoreCal();
        }
        else
        {

        }
       
    }

    void ScoreCal()
    {
        coinScore = UI_Coin.Instance.score * 100;
        gemScore = UI_Gem.Instance.score * 1000;
        gameScore = Mathf.RoundToInt(timeScore) + coinScore + gemScore;
    }

}
