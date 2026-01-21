using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
	[SerializeField] Button button;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Invoke("a", 0.1f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void a() {
		button.onClick.Invoke();
	}
}
