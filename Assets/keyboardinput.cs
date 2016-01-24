using UnityEngine;
using System.Collections;

public class keyboardinput : MonoBehaviour {

	public GameObject cube;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("c")) {
			Instantiate(cube, new Vector3(cube.transform.position.x, cube.transform.position.y + 2, cube.transform.position.z), cube.transform.rotation);

		}
	
	}
}
