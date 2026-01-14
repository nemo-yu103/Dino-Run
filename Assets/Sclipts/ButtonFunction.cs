using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] UI_Count ui;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject titleui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart() {

        ui.StartCountDown();
        uiManager.DisplayUI();
        titleui.SetActive(true);

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
}
