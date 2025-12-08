using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    public static UI_HP Instance;

    public SpriteResolver HP_4;
    public SpriteResolver HP_3;
    public SpriteResolver HP_2;
    public SpriteResolver HP_1;
    public SpriteResolver HP_0;

    private int life = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage()
    {
        Debug.Log("OK");
        life--;
        UpdateHP();
    }

    void UpdateHP()
    {
        int remHP_4 = life % 5;
        Debug.Log(remHP_4);
        int remHP_3 = life % 4;
        int remHP_2 = life % 3;
        int remHP_1 = life % 2;
        
        HP_4.SetCategoryAndLabel("HP_4", remHP_4.ToString());
        HP_3.SetCategoryAndLabel("HP_3", remHP_3.ToString());
        HP_2.SetCategoryAndLabel("HP_2", remHP_2.ToString());
        HP_1.SetCategoryAndLabel("HP_1", remHP_1.ToString());
        if(life <= 0)
        {
            HP_0.SetCategoryAndLabel("HP_0","0_0" );
        }
            
    }
}
