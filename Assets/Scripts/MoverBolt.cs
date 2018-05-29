using UnityEngine;
using System.Collections;

public class MoverBolt : MonoBehaviour
{
	public Rigidbody rb;
	public float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}
}
