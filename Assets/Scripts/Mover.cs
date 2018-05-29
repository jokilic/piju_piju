using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Rigidbody rb;
	public Faster speedUp;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		speedUp = GameObject.Find ("GameController").GetComponent<Faster> ();
		rb.velocity = Vector3.forward * speedUp.speed;
	}
}
