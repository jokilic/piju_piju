﻿using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	public Rigidbody rb;
	public float tumble;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
