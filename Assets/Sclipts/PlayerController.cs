using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Scripting;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int HP;
    private bool isGround = true;
    //public int getCoin = 0;
    Rigidbody2D rb;
    public Animator animator;

    public GameObject hpui;


    public UI_HP hpUI4;
    public UI_HP hpUI3;
    public UI_HP hpUI2;
    public UI_HP hpUI1;
    public UI_HP hpUI0;

    void Start()
    {
        jumpForce = 7f;
        HP = 5;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }

        if (transform.position.x <= -10)
        {
            HP -= 5;
            Die();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ジャンプできるかの判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ダメージを受ける
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.name == "coin(Clone)")
            {
                UI_Coin.Instance.AddCoin();
            }
            else if (collision.gameObject.name == "gem(Clone)")
            {
                UI_Gem.Instance.AddGem();
            }
        }

    }

    public void Damage()
    {
        HP -= 1;
        

        if (HP == 0)
        {
            Die();
        }
        else
        {
            animator.SetBool("isDamage", true);
        }
        Invoke(nameof(EndDamgeAnimation), 1.5f);

        hpUI4.UpdateHPUI4(HP);
        hpUI3.UpdateHPUI3(HP);
        hpUI2.UpdateHPUI2(HP);
        hpUI1.UpdateHPUI1(HP);
        hpUI0.UpdateHPUI0(HP);
    }

    private void EndDamgeAnimation()
    {
        animator.SetBool("isDamage", false);
    }


    void Die()
    {
        animator.SetTrigger("Die");
        GameManager.Instance.GameOver();

        Invoke("Destroy", 3f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
        Invoke("GameOverScreen", 1.5f);
    }

    void GameOverScreen()
    {
        
    }

}
