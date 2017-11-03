using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ADMOptions : MonoBehaviour
{
	int opt;
	public GameObject checkSom;
	// Use this for initialization
	void Start ()
	{
		checkSom = GetComponent<GameObject> ();
		LerSom ();
	}

	void AtivaOuDesativaSom ()
	{
		if (opt == 1) {
			AudioListener.pause = true;
			AudioListener.volume = 0f;
		} else if (opt == 0) {
			AudioListener.pause = false;
			AudioListener.volume = 1.0f;
		}
	}

	void OnEnable ()
	{
		LerSom ();
	}

	void LerSom()
	{
		BDClass.LerSom (ref opt);
		if (opt == 0) 
		{
			checkSom.GetComponent<Toggle>().isOn = true;
		} 
		else if (opt == 1)
			checkSom.GetComponent<Toggle>().isOn = false;
		AtivaOuDesativaSom ();
	}

	public void MudaSom ()
	{
		BDClass.AlteraSom ();
		AtivaOuDesativaSom ();
	}
}
