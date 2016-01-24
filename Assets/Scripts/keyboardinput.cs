using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

using System.Xml.Serialization;

[Serializable]
public class Poly {
	public PolyPart[] Parts;
	public string Name;

    //public static poly load(string file) {

    //}

}

[Serializable]
public class PolyPart {
	public Vector3 Position;

}

public class keyboardinput : MonoBehaviour {

	public GameObject cube;
	private GameObject currentObject;
	private GameObject parent;


	List<GameObject> clones = new List<GameObject>();
	// Use this for initialization
	void Start () {
		parent = new GameObject ();
	
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown ("c")) {

            if (currentObject != null) {
                currentObject.GetComponent<Renderer>().material.color = Color.white;
            }

            currentObject = (GameObject) Instantiate(cube, new Vector3(cube.transform.position.x, cube.transform.position.y + 2, cube.transform.position.z), cube.transform.rotation);
			currentObject.transform.parent = parent.transform;
			currentObject.SetActive(true);
			clones.Add(currentObject);

            currentObject.GetComponent<Renderer>().material.color = Color.yellow;

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
			//var clones = parent.transform.GetComponentsInChildren<Component>().Select( s => s.gameObject ).ToList();

			if (currentObject == null) {
				currentObject = clones[0];
			} else {
				var index = clones.IndexOf (currentObject);
				if (index == 0) {
					index = clones.Count;
				}
				currentObject.GetComponent<Renderer>().material.color = Color.white;
				currentObject =  clones [index - 1];
				currentObject.GetComponent<Renderer>().material.color = Color.yellow;
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//var clones = parent.transform.<Component>().Select( s => s.gameObject ).ToList();
			if (currentObject == null) {
				currentObject = clones [0].gameObject;
			} else {
				var index = clones.IndexOf (currentObject);
				if (index == clones.Count - 1) {
					index = -1;
				}
				currentObject.GetComponent<Renderer>().material.color = Color.white;
				currentObject = clones [index + 1];
				var renderer = currentObject.GetComponent<Renderer>();

				renderer.material.color = Color.yellow;
			}
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Poly p = new Poly();
			p.Parts = clones.Select(s => new PolyPart{ Position = s.transform.position }).ToArray();
			XmlSerializer xml = new XmlSerializer(typeof(Poly));

			
			FileStream file = File.Create (Application.persistentDataPath + "/test.gd");
			xml.Serialize(file, p);

			file.Close();
		}
	}
}
