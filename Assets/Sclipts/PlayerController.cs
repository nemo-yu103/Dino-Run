using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int HP;
    private bool isGround = true;
    Rigidbody2D rb;

    void Start()
    {
        jumpForce = 5f;
        HP = 3;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        //ƒWƒƒƒ“ƒv‚Å‚«‚é‚©‚Ì”»’è
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            HP -= 1;
            if(HP == 0)
            {
                GameOver();
            }
        }

    }

    void GameOver()
    {

    }

}
