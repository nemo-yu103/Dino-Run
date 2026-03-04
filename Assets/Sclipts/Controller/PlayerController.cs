using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] UI_HP uI_HP; 
    [SerializeField] private AudioClip jumpSE;
    [SerializeField] private AudioClip getCoinSE;
    [SerializeField] private AudioClip getGemSE;
    [SerializeField] private AudioClip deathSE;
    [SerializeField] private AudioClip damageSE;
    [SerializeField] private AudioClip bananaSE;
    [SerializeField] private AudioClip appleSE;

    //[SerializeField]
    //UI_HP[] ui_hp = new UI_HP[5];

    [Header("ステータス")]
    public float jumpForce;
    public int HP;

    private bool isGround = true;
    public bool isSurvival = true;
    private bool isSEPlaying = false;

    Rigidbody2D rb;

    public Animator animator;

    public GameObject hpui;

    //public UI_HP hpUI4;
    //public UI_HP hpUI3;
    //public UI_HP hpUI2;
    //public UI_HP hpUI1;
    //public UI_HP hpUI0;


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
        if (transform.position.x <= -6 && isSurvival)
        {
            transform.Translate(3f * Time.deltaTime, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            AudioManager.Instance.PlaySE(jumpSE);
        }

        //画面外に出たら死亡
        if (transform.position.x <= -10)
        {
            while (HP == 0)
            {
                HP -= 1;
            }
            
            Die();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(jumpEffectPrefab,transform.position + new Vector3(0,0.1f,0), Quaternion.identity);
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
                jumpForce += 1f;
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
        //hpUI4.UpdateHPUI4(HP);
        //hpUI3.UpdateHPUI3(HP);
        //hpUI2.UpdateHPUI2(HP);
        //hpUI1.UpdateHPUI1(HP);
        //hpUI0.UpdateHPUI0(HP);
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
