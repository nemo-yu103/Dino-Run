using UnityEngine;
using UnityEngine.U2D.Animation;

public class UI_Score : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PlayerController playerController;

    public SpriteResolver[] sr = new SpriteResolver[9];


    void Start()
    {

    }

    void Update()
    {
        if (playerController.isSurvival == true)
        {
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int gameScore = scoreManager.gameScore;
        for (int i = 8; i > -1; i--)
        {
            float divi = gameScore / Mathf.Pow(10, i);
            int answer = (int)divi;
            sr[i].SetCategoryAndLabel(Mathf.Pow(10, i).ToString("F0"), answer.ToString());
            gameScore = gameScore - (answer * (int)Mathf.Pow(10, i));
        }
    }
}
