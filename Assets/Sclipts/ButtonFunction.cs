using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] UI_Count ui;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject titleui;
    [SerializeField] AnimationChanger changer;
    [SerializeField] private AudioClip clickSE;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ButtonStart() {

        AudioManager.Instance.PlaySE(clickSE);
        ui.StartCountDown();
        uiManager.DisplayUI();
        Destroy(this.gameObject.transform.parent.parent.gameObject);

	return;
    }

    public void ButtonExit() {

        AudioManager.Instance.PlaySE(clickSE);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        #endif

        return;
    }

    public void ButtonSkin()
    {
        AudioManager.Instance.PlaySE(clickSE);
        changer.OnSkinButtonClick();
    }
}
