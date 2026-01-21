using UnityEngine;
using UnityEngine.U2D.Animation;

public class ChangeMapSkin : MonoBehaviour
{
    [SerializeField]ScoreManager scoreManager;

    public SpriteResolver[] sr = new SpriteResolver[14];

    int nextScore = 1000;
    string str;

    private void Awake()
    {
        sr[12].SetCategoryAndLabel("Brock_1", 0.ToString());
        sr[13].SetCategoryAndLabel("Brock_2", 0.ToString());
    }


    void Update()
    {
        if (scoreManager.gameScore >= nextScore)
        {
            ChangeMap();
            nextScore += 1000;
        }
    }

    void ChangeMap()
    {
        int skinNo = Random.Range(0, 3);
        Debug.Log(skinNo);
        for(int i = 0; i < 14; i++)
        {
            if (i >= 0 && i < 6)
            {
                str = "Ground";
            }
            else if(i >=6 && i < 9)
            {
                str = "Backgrounds";
            }
            else if(i >= 9 && i < 12)
            {
                str = "Sky";
            }
            else if (i == 12)
            {
                str = "Brock_1";
            }
            else if( i == 13)
            {
                str = "Brock_2";
            }
                sr[i].SetCategoryAndLabel(str, skinNo.ToString());
        }
        //sr.SetCategoryAndLabel("Ground",skinNo.ToString());
    }
}
