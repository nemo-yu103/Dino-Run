using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int HP;
    private bool isGround = true;
    Rigidbody2D rb;

    void Start()
    {
        jumpForce = 7f;
        HP = 3;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
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
            HP -= 1;

            if (HP == 0)
            {
                GameOver();
            }
        }

    }


    void GameOver()
    {

    }

}
