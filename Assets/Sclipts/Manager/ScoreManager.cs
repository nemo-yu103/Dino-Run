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
    public int changeSpeed = 4000;


    void Start()
    {
        
    }

    void Update()
    {
        if (ScrollManager.Instance == null)
        {
            return;
        }

        if (judge.gameNow == true)
        {
            timeScore += Time.deltaTime;
            
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

        if(gameScore > changeSpeed)
        {
            ChangeGameSpeed();
        }
    }

    void ChangeGameSpeed()
    {
        Time.timeScale += 1.2f * Time.deltaTime;
        changeSpeed += 4000;
    }

}
