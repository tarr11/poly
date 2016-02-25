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
    float fillerX = 0;
    float fillerY = 0;
    float fillerZ = 0;
    int selectedNum = 0;
    enum FillMode {
        Plane, Row, Point, Empty
    };
    FillMode fillMode;

    // Use this for initialization
    void Start() {
        parent = new GameObject();
        Cursor.lockState = CursorLockMode.Locked;
        fillMode = FillMode.Plane;
    }

    GameObject NewCube() {

        if (currentObject != null) {
            currentObject.GetComponent<Renderer>().material.color = Color.white;
        }

        currentObject = (GameObject)Instantiate(cube);
        currentObject.transform.SetParent(parent.transform);
        currentObject.SetActive(true);
        clones.Add(currentObject);

        currentObject.GetComponent<Renderer>().material.color = Color.yellow;

        //updatePosition (cur);

        return currentObject;
    }

    GameObject NewFillerCube() {
        currentFiller = (GameObject)Instantiate(filler);
        currentFiller.transform.SetParent(parent.transform);
        currentFiller.SetActive(true);
        fillerClones.Add(currentFiller);

        return currentFiller;
    }

    void updatePosition(float x, float y, float z) {
        Position.text = string.Format("{0},{1},{2}", x, y, z);
    }

    // Update is called once per frame
    void Update() {
        bool isKeyDown = false;
        for (var num = 0; num < 10; num++) {
            if (Input.GetKeyDown("" + num)) {
                selectedNum = num;
                isKeyDown = true;
            }
        }
        if (isKeyDown) {
            if (fillMode == FillMode.Plane) {
                foreach (var f in fillerClones) {
                    Destroy(f);
                }
                fillerClones.Clear();
                for (var i = 0; i < 9; i++) {
                    for (var j = 0; j < 9; j++) {
                        var gameObj = NewFillerCube();
                        fillerX = selectedNum;
                        gameObj.transform.position = new Vector3(fillerX, j, i);
                        fillMode = FillMode.Row;

                        updatePosition(fillerX, fillerY, fillerZ);
                    }
                }
            } else if (fillMode == FillMode.Row) {
                foreach (var f in fillerClones) {
                    Destroy(f);
                }
                fillerClones.Clear();

                for (var i = 0; i < 9; i++) {
                    var gameObj = NewFillerCube();
                    fillerY = selectedNum;
                    gameObj.transform.position = new Vector3(fillerX, fillerY, i);
                    fillMode = FillMode.Point;

                    updatePosition(fillerX, fillerY, fillerZ);
                }
            } else if (fillMode == FillMode.Point) {
                foreach (var f in fillerClones) {
                    Destroy(f);
                }
                fillerClones.Clear();
                var gameObj = NewFillerCube();
                fillerZ = selectedNum;
                gameObj.transform.position = new Vector3(fillerX, fillerY, fillerZ);
                fillMode = FillMode.Plane;

                updatePosition(fillerX, fillerY, fillerZ);
            }
        }
        /*
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
        */
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
            foreach (var f in fillerClones) {
                Vector3 pos = f.transform.position;
                var cube = NewCube();
                cube.transform.position = pos;
                Destroy(f);
            }
            fillMode = FillMode.Plane;
            fillerClones.Clear();
        }

        /*
		if (Input.GetKeyDown (KeyCode.Return)) {
			
			Poly p = new Poly();
			p.Name = this.PolyName.text;
			p.Parts = clones.Select(s => new PolyPart{ Position = s.transform.position }).ToList();

			var json = JsonUtility.ToJson(p);

			using (var writer = new StreamWriter (Application.persistentDataPath + "/" +  p.Name + ".gd")) {
				writer.Write (json);
			}
	
		}
        */

		if (Input.GetKey (KeyCode.Escape)) {
            if (Cursor.lockState == CursorLockMode.None) {
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                Cursor.lockState = CursorLockMode.None;
            }
		}


		if (Input.anyKeyDown) {
			//updatePosition ();
		}
	}
}
