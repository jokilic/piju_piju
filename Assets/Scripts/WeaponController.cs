using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float delay;
	private AudioSource audioSource;
	private float fireRate;
	
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		StartCoroutine (Fire ());
	}

	private IEnumerator Fire ()
	{
		while (true)
		{
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
			yield return new WaitForSeconds (Random.Range (2.5f, 5f));
		}
	}
}
