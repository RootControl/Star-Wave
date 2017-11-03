using UnityEngine;
using System.Collections;

public class DestruirTiro : MonoBehaviour {

	void OnTriggerExit (Collider other)
	{
		Destroy (other.gameObject);
	}
}
