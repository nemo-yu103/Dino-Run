using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private int life = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage()
    {

    }
}
