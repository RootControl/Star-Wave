using UnityEngine;
using System.Collections;

public class AxisRotate : MonoBehaviour {

	public float speed = 2f;
	
	// Update is called once per frame
	void FixedUpdate () {
	

		if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow))) {
			Left ();
		}

		if ((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow))) {
			Right ();
		}		
	}

	public void Left () {

		Vector3 destEuler = transform.localEulerAngles;

		destEuler.z -= speed * Time.deltaTime;

		Vector3 currEuler = transform.localEulerAngles;

		currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
		transform.localEulerAngles = currEuler;

	}

	public void Right () {

		Vector3 destEuler = transform.localEulerAngles;

		destEuler.z += speed * Time.deltaTime;

		Vector3 currEuler = transform.localEulerAngles;

		currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
		transform.localEulerAngles = currEuler;

	}
}
