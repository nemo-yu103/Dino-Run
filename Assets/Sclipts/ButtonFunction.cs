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
	Debug.Log("sgw");
        ui.StartCountDown();

    }
}
