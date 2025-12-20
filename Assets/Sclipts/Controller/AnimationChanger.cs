using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
	Animator anim;
	[SerializeField] AnimatorOverrideController[] aoc;
	[SerializeField] int m;

	void Start()
	{
		anim = GetComponent<Animator>();
		ChangeColor(m);
	}

	void Update()
	{
		
	}

	void ChangeColor(int n) {
		anim.runtimeAnimatorController = aoc[n];
	}
}

	