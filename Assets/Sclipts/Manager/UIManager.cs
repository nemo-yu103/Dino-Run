using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject ui_coin;
    [SerializeField] GameObject ui_gem;
    [SerializeField] GameObject ui_hp;
    [SerializeField] GameObject ui_score;


    void Start()
    {
        
    }

    void Update()
    {
        if (playerController.isSurvival == false)
        { 
            HideUI();
        }
    }

    void HideUI()
    {
        ui_coin.SetActive(false);
        ui_gem.SetActive(false);
        ui_hp.SetActive(false);
        ui_score.SetActive(false);
    }
}
