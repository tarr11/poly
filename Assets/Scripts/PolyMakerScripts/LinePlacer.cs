using UnityEngine;
using System.Collections;

public class LinePlacer : MonoBehaviour {

	public GameObject lineObject;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < 9; i++) {
			var line = GameObject.Instantiate<GameObject> (lineObject);
			line.SetActive (true);
			line.transform.Translate (new Vector3 (1, 0, 0) * i);

		}

		lineObject.transform.position = new Vector3 (4, -0.5f, 8.5f);
		lineObject.transform.Rotate (0, 90, 0);
		lineObject.GetComponent<Renderer>().material.color = Color.white;

		for (var i = 0 ; i < 9; i++)
		{
			var line = GameObject.Instantiate<GameObject> (lineObject);
			line.SetActive (true);
			line.transform.Translate (new Vector3 (1, 0, 0) * i);
		}

		// sides
		//var side = GameObject.Instantiate<GameObject> (lineObject);
		//side.transform.Rotate(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
