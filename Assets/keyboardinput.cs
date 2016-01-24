using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class keyboardinput : MonoBehaviour {

	public GameObject cube;
	private GameObject currentObject;
	List<GameObject> clones = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("c")) {
			currentObject = (GameObject) Instantiate(cube, new Vector3(cube.transform.position.x, cube.transform.position.y + 2, cube.transform.position.z), cube.transform.rotation);
			clones.Add (currentObject);
		}
		if (Input.GetKeyDown ("w")) {
			currentObject.transform.Translate (Vector3.forward);
		}
		if (Input.GetKeyDown ("s")) {
			currentObject.transform.Translate (Vector3.back);
		}
		if (Input.GetKeyDown ("a")) {
			currentObject.transform.Translate (Vector3.left);
		}
		if (Input.GetKeyDown ("d")) {
			currentObject.transform.Translate (Vector3.right);
		}
		if (Input.GetKeyDown ("q")) {
			currentObject.transform.Translate (Vector3.up);
		}
		if (Input.GetKeyDown ("e")) {
			currentObject.transform.Translate (Vector3.down);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (currentObject == null) {
				currentObject = clones [0];
			} else {
				var index = clones.IndexOf (currentObject);
				if (index == 0) {
					index = clones.Count;
				}
				currentObject.GetComponent<Renderer>().material.color = Color.white;
				currentObject = clones [index - 1];
				currentObject.GetComponent<Renderer>().material.color = Color.yellow;
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (currentObject == null) {
				currentObject = clones [0];
			} else {
				var index = clones.IndexOf (currentObject);
				if (index == clones.Count - 1) {
					index = -1;
				}
				currentObject.GetComponent<Renderer>().material.color = Color.white;
				currentObject = clones [index + 1];
				currentObject.GetComponent<Renderer>().material.color = Color.yellow;
			}
		}
	}
}
