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

}
