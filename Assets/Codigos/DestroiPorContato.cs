using UnityEngine;
using System.Collections;

public class DestroiPorContato : MonoBehaviour {

	public GameObject Explosao;
	public GameObject PlayerExplosao;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Limite" || other.tag == "Enemy") {
//			return;
		}

		if (Explosao != null) {
			Instantiate (Explosao, transform.position, transform.rotation);
		}
			

		if (other.tag == "Player") {
			Instantiate (PlayerExplosao, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
