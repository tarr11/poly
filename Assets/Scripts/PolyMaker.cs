using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using UnityEngine.UI;
using System.Xml.Serialization;





public class PolyMaker : MonoBehaviour {

	public GameObject cube;
	public GameObject filler;
	public InputField PolyName;
	public Text Position;

	GameObject currentObject;
	GameObject currentFiller;
	GameObject parent;
	List<GameObject> clones = new List<GameObject>();
	List<GameObject> fillerClones = new List<GameObject>();
	enum FillMode {
		Plane, Row, Point, Empty
	};
	FillMode fillMode;

	// Use this for initialization
	void Start () {
		parent = new GameObject ();
		Cursor.lockState = CursorLockMode.Locked;
	}
		
	GameObject NewCube() {

		if (currentObject != null) {
			currentObject.GetComponent<Renderer>().material.color = Color.white;
		}

		currentObject = (GameObject)Instantiate (cube);//, new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z), cube.transform.rotation);
		currentObject.transform.SetParent(parent.transform);
		currentObject.SetActive(true);
		clones.Add(currentObject);

		currentObject.GetComponent<Renderer>().material.color = Color.yellow;

		updatePosition ();

		return currentObject;
	}

	GameObject NewFillerCube() {
		currentFiller = (GameObject)Instantiate (filler);
		currentFiller.transform.SetParent(parent.transform);
		currentFiller.SetActive(true);
		fillerClones.Add (currentFiller);

		return currentFiller;
	}

	void updatePosition () {
		Position.text = string.Format("{0},{1},{2}", currentObject.transform.position.x, currentObject.transform.position.y, currentObject.transform.position.z);
	}

	// Update is called once per frame
	void Update () {

	
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (fillMode == FillMode.Plane) {
				for (var i = 0; i < 9; i++) {
					for (var j = 0; j < 9; j++) {
						var gameObj = NewFillerCube ();
						gameObj.transform.position = new Vector3 (i, 0, j);
					}

				}
			}

			if (fillMode == FillMode.Row) {
				foreach (var f in fillerClones) {
					if (f.transform.position.y == currentFiller.transform.position.y)
				}
			}
		}

        if (Input.GetKeyDown ("c")) {
			NewCube ();
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
			p.Name = this.PolyName.text;
			p.Parts = clones.Select(s => new PolyPart{ Position = s.transform.position }).ToList();

			var json = JsonUtility.ToJson(p);

			using (var writer = new StreamWriter (Application.persistentDataPath + "/" +  p.Name + ".gd")) {
				writer.Write (json);
			}
	
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}


		if (Input.anyKeyDown) {
			updatePosition ();
		}
	}
}
