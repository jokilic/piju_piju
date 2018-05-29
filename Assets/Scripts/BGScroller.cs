using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
	public float speed;

	void Update ()
	{
		Vector2 offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
