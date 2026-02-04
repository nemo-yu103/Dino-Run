using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] UI_Count ui;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject titleui;
    [SerializeField] AnimationChanger changer;

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ButtonStart() {

        ui.StartCountDown();
        uiManager.DisplayUI();
        Destroy(this.gameObject.transform.parent.parent.gameObject);

	return;
    }

    public void ButtonExit() {

        # if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        # else
            Application.Quit();
        #endif

        return;
    }

    public void ButtonSkin()
    {
        changer.OnSkinButtonClick();
    }
}
