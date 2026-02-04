using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    [SerializeField] GameObject[] hpUI = new GameObject[5];
    [SerializeField] Sprite sprite;
    [SerializeField] Sprite sprite2;
    [SerializeField] PlayerController playerController;

    SpriteRenderer image;

    
    //public Animator animator;


    public void Damage()
    {

        int HP = playerController.HP;
        image = hpUI[HP].GetComponent<SpriteRenderer>();
        
        image.sprite = sprite;
    }

    public void Heal()
    {
        int HP = playerController.HP;
        image = hpUI[HP].GetComponent <SpriteRenderer>();

        image.sprite = sprite2;
    }


    //public void UpdateHPUI4(int HP)
    //{
    //    //HP = Mathf.Clamp(HP, 0, hpSprites.Length - 1);
    //    //hpImage = hpSprites[HP];
    //    if (HP == 4)
    //    {
    //        animator.SetBool("IsDamage4", true);
    //        Debug.Log(HP);
    //    }
    //}

    //public void UpdateHPUI3(int HP)
    //{
    //    if (HP == 3)
    //    {
    //        animator.SetBool("IsDamage3", true);
    //    }

    //}

    //public void UpdateHPUI2(int HP)
    //{
    //    if (HP == 2)
    //    {
    //        animator.SetBool("IsDamage2", true);
    //    }

    //}

    //public void UpdateHPUI1(int HP)
    //{
    //    if (HP == 1)
    //    {
    //        animator.SetBool("IsDamage1", true);
    //    }

    //}

    //public void UpdateHPUI0(int HP)
    //{
    //    if (HP == 0)
    //    {
    //        animator.SetBool("IsDamage0", true);
    //    }
    //}
}
