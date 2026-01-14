using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject ui_coin;
    [SerializeField] GameObject ui_gem;
    [SerializeField] GameObject ui_hp;
    [SerializeField] GameObject ui_score;
    [SerializeField] GameObject ui_gamescore;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerController.isSurvival == false)
        { 
            HideUI();
            Invoke("GameScoreDisplay", 5f);
        }
    }

    public void HideUI()
    {
        ui_coin.SetActive(false);
        ui_gem.SetActive(false);
        ui_hp.SetActive(false);
        ui_score.SetActive(false);
    }

    public void DisplayUI()
    {
        ui_coin.SetActive(true);
        ui_gem.SetActive(true);
        ui_hp.SetActive(true);
        ui_score.SetActive(true);
    }

    void GameScoreDisplay()
    {
        ui_gamescore.SetActive(true);
    }
}
