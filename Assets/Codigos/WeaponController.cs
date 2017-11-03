using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	private AudioSource audioSource;
	public Transform shotSpaw;
	public float fireRate;
	public float delay;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate (shot, shotSpaw.position, shotSpaw.rotation);
		audioSource.Play ();
	}
}