using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] UI_HP uI_HP;
    [SerializeField] ScrollMap map;
    [SerializeField] private AudioClip jumpSE;
    [SerializeField] private AudioClip getCoinSE;
    [SerializeField] private AudioClip getGemSE;
    [SerializeField] private AudioClip deathSE;
    [SerializeField] private AudioClip damageSE;
    [SerializeField] private AudioClip bananaSE;
    [SerializeField] private AudioClip appleSE;

    [Header("ステータス")]
    public float jumpForce;
    public int HP;

    private bool isGround = true;
    public bool isSurvival = true;
    private bool isSEPlaying = false;
    private bool isFastFalling = false;

    float dashSpeed = 5f;
    float dashTime = 2f;

    Rigidbody2D rb;
    float nprmalGravity = 1f;
    float fastGravity = 10f;

    int bananaPower = 0;

    public Animator animator;

    public GameObject hpui;

    public GameObject coinEffectPrefab;
    public GameObject jumpEffectPrefab;
    public GameObject hitEffectPrefab;

    void Start()
    {
        jumpForce = 7f;
        HP = 5;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //画面外に出たら死亡
        if (transform.position.x <= -10)
        {
            while (HP == 0)
            {
                HP -= 1;
            }

            Die();
        }

        if (transform.position.x <= -6 && isSurvival)
        {
            transform.Translate(3f * Time.deltaTime, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            AudioManager.Instance.PlaySE(jumpSE);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && !isGround && !isFastFalling)
        {
            isFastFalling = true;
        }

        if(isFastFalling)
        {
            rb.gravityScale = fastGravity;
        }
        else
        {
            rb.gravityScale = nprmalGravity;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && bananaPower > 0)
        {
            bananaPower -= 1;
            StartCoroutine(Dash());
        }

    }

    IEnumerator Dash()
    {
        map.isDashing = true;

        yield return new WaitForSeconds(2f);

        map.isDashing = false;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(jumpEffectPrefab,transform.position + new Vector3(0,0.1f,0), Quaternion.identity);
        //isGround = false;
        OutGeround();
    }

    void OutGeround()
    {
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ジャンプできるかの判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isFastFalling = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ダメージを受ける
        if (collision.gameObject.CompareTag("Enemy") && !map.isDashing)
        {
            Damage();
            AudioManager.Instance.PlaySE(damageSE,1.2f);
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Instantiate(coinEffectPrefab, transform.position + new Vector3(0,1.5f,0), Quaternion.identity);

            Destroy(collision.gameObject);
            if (collision.gameObject.name == "coin(Clone)")
            {
                AudioManager.Instance.PlaySE(getCoinSE,0.5f);
                UI_Coin.Instance.AddCoin();
            }
            else if (collision.gameObject.name == "gem(Clone)")
            {
                AudioManager.Instance.PlaySE(getGemSE);
                UI_Gem.Instance.AddGem();
            }
        }

        if (collision.gameObject.CompareTag("Fluits"))
        {
            if(collision.gameObject.name == "apple(Clone)")
            {
                AudioManager.Instance.PlaySE(appleSE,1.2f);
                Destroy(collision.gameObject);
                if(HP <= 4)
                {
                    uI_HP.Heal();
                    HP += 1;
                }
            }
            else if (collision.gameObject.name == "banana(Clone)")
            {
                AudioManager.Instance.PlaySE(bananaSE,1.2f);
                Destroy(collision.gameObject);
                if(bananaPower < 5)
                {
                    bananaPower += 1;
                }
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

        uI_HP.Damage();
        
    }

    private void EndDamgeAnimation()
    {
        animator.SetBool("isDamage", false);
    }


    void Die()
    {
        isSurvival = false;
        
        animator.SetTrigger("Die");
        if(!isSEPlaying)
        {
            AudioManager.Instance.PlaySE(deathSE,1.2f);
            isSEPlaying = true;
        }
        GameManager.Instance.GameOver();

        Invoke("Destroy", 3f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
