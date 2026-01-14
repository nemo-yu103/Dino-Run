using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] UI_Count ui;

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
}
