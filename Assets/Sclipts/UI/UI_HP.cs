using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    private PlayerController playerController;
    public Animator animator;


    public void UpdateHPUI4(int HP)
    {
        //HP = Mathf.Clamp(HP, 0, hpSprites.Length - 1);
        //hpImage = hpSprites[HP];
        if (HP == 4)
        {
            animator.SetBool("IsDamage4", true);
            Debug.Log(HP);
        }
    }

    public void UpdateHPUI3(int HP)
    {
        if (HP == 3)
        {
            animator.SetBool("IsDamage3", true);
        }

    }

    public void UpdateHPUI2(int HP)
    {
        if (HP == 2)
        {
            animator.SetBool("IsDamage2", true);
        }

    }

    public void UpdateHPUI1(int HP)
    {
        if (HP == 1)
        {
            animator.SetBool("IsDamage1", true);
        }

    }

    public void UpdateHPUI0(int HP)
    {
        if (HP == 0)
        {
            animator.SetBool("IsDamage0", true);
        }
    }
}
