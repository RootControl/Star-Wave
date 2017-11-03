using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ADMRanking : MonoBehaviour 
{
	public Text[] names = new Text[5];
	public Text[] score = new Text[5];

	string[] referencia1 = new string[5];
	string[] referencia2 = new string[5];
	// Use this for initialization
	void Start () 
	{
		// names
		names [0] = GetComponent<Text> ();
		names [1] = GetComponent<Text> ();
		names [2] = GetComponent<Text> ();
		names [3] = GetComponent<Text> ();
		names [4] = GetComponent<Text> ();
		// scores
		score [0] = GetComponent<Text> ();
		score [1] = GetComponent<Text> ();
		score [2] = GetComponent<Text> ();
		score [3] = GetComponent<Text> ();
		score [4] = GetComponent<Text> ();
	}
		
	public void OnEnable ()
	{
		int quant = 0;
		BDClass.LerRanking (referencia1, referencia2, ref quant);
		Debug.Log (quant.ToString ());
		switch (quant) 
		{
			case 1:
				PreencheRanking (quant);
				break;
			case 2:
				PreencheRanking (quant);
				break;
			case 3:
				PreencheRanking (quant);
				break;
			case 4:
				PreencheRanking (quant);
				break;
			case 5: 
				PreencheRanking (quant);
				break;
		}
	}

	void PreencheRanking (int quant)
	{
		for (int i = 0; i <= quant; i++) 
		{
			names [i].text = referencia1 [i];
			score [i].text = referencia2 [i];
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
