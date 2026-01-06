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
        int one = ;
    }
}
