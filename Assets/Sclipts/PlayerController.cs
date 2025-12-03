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


    public UIController hpUI;
    public UIController hpUI1;
    public UIController hpUI2;
    public UIController hpUI3;
    public UIController hpUI4;

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
                //getCoin++;
                UI_coingem.Instance.AddCoin();
            }
            else if (collision.gameObject.name == "gem(Clone)")
            {
                UI_coingem.Instance.AddGem();
            }
            //Debug.Log(getCoin);
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
        Invoke(nameof(EndDamgeAnimation), 2f);

        hpUI.UpdateHPUI(HP);
        hpUI1.UpdateHPUI1(HP);
        hpUI2.UpdateHPUI2(HP);
        hpUI3.UpdateHPUI3(HP);
        hpUI4.UpdateHPUI4(HP);

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
