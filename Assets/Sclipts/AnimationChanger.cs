using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
	public Texture replacetexture;

	private SpriteRenderer spriteRenderer;
	private static int idMainTex = Shader.PropertyToID("_MainTex");
	private MaterialPropertyBlock block;

	void Start()
	{
		block = new MaterialPropertyBlock();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.GetPropertyBlock(block);
	}

	void Update()
	{
		block.SetTexture(idMainTex, replacetexture);
		spriteRenderer.SetPropertyBlock(block);
	}

}

	