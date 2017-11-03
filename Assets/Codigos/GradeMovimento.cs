using UnityEngine;
using System.Collections;

public class GradeMovimento : MonoBehaviour {

	private Material currentmaterial;
	public Renderer rd;
	public float speed;
	private float offset;

	// Use this for initialization
	void Start () {
		currentmaterial = rd.material;
	}

	// Update is called once per frame
	void Update () {
		offset += 0.001f;
		currentmaterial.SetTextureOffset ("_MainTex", new Vector2 (0, offset * speed));
	}
}
