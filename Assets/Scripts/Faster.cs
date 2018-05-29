using UnityEngine;
using System.Collections;

public class Faster : MonoBehaviour
{
	public float speed;

	void Start()
	{
		InvokeRepeating ("SpeedUp", 25.0f, 15.0f);
	}

	void SpeedUp()
	{
		speed -= 5;
	}
}
