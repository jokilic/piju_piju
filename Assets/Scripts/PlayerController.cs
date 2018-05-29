using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	private float speed;
	public Boundary boundary;
	public Rigidbody rb;
	public AudioSource zvuk;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private Quaternion calibrationQuaternion;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		zvuk = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (((Input.touchCount > 0) || Input.GetButton("Fire1")) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			zvuk.Play ();
		}
	}

	void FixedUpdate ()
	{
		if (SystemInfo.deviceType == DeviceType.Desktop)
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			speed = 20;
			rb.velocity = movement * speed;
		} 

		else
		{
			Vector3 acceleration = Input.acceleration;
			Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y + 0.5f);
			speed = 30;
			rb.velocity = movement * speed;
		}

		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);
	}
}
