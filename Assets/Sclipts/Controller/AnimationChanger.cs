using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
	Animator anim;
	[SerializeField] AnimatorOverrideController[] aoc;
	int charaskinNo;

	void Start()
	{
		anim = GetComponent<Animator>();
		
	}

	void Update()
	{
		
	}

	public void OnSkinButtonClick()
	{
		charaskinNo++;
		if(charaskinNo >= aoc.Length)
		{
			charaskinNo = 0;
		}
		ChangeColor(charaskinNo);
	}

	void ChangeColor(int n) {
		anim.runtimeAnimatorController = aoc[n];
	}
}

	