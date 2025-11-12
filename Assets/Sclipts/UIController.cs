using UnityEngine;

public class UIController : MonoBehaviour
{
    private PlayerController playerController;
    int d = 0;

    
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        playerController.HP = 1;//ダメージを受けたら、isDamageをtrueにする←次やること
    }
}
