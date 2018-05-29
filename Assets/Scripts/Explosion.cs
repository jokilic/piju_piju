using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{

	public Sprite[] sprites;
	public float wait;

	void Start()
	{
		StartCoroutine(SwitchSprite());
	}

	private IEnumerator SwitchSprite()
	{
		for (int i = 0; i < sprites.Length; i++)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [i];
			yield return new WaitForSeconds (wait);
		}
		Destroy(gameObject);
	}
}
