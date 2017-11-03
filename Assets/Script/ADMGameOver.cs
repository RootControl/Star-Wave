using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ADMGameOver : MonoBehaviour 
{
	public string nome, score;

	void OnEnable ()
	{
		score = GameController.score.ToString ();
		GameObject.Find ("ScoreFinal").GetComponent<Text> ().text = score;
	}

	public void GravarInsert ()
	{
		nome = GameObject.Find ("TextColocarNome").GetComponent<Text> ().text;
		score = GameObject.Find ("ScoreFinal").GetComponent<Text> ().text;
		BDClass.InsertBD (nome, score);
	}
}
