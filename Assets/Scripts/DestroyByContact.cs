using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DestroyByContact : MonoBehaviour
{
	public GameObject asteroidExp;
	public GameObject playerExp;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
		
		if(gameController == null)
			Debug.Log("Cannot find 'GameController' script");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Boundary")  || other.CompareTag ("Enemy"))
			return;

		if(asteroidExp != null)
			Instantiate (asteroidExp, transform.position, transform.rotation);

		if (other.CompareTag ("Player"))
		{
			Instantiate (playerExp, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
