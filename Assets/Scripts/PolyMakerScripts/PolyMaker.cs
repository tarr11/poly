using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PolyMaker : MonoBehaviour {

    public GameObject cube;
    public GameObject filler;
    public Text Position;
    public InputField PolyName;
    public GameObject EscMenu;
    public GameObject ShownMenu;
    public List<GameObject> clones = new List<GameObject>();

    GameObject currentObject;
    GameObject currentFiller;
    GameObject parent;
    List<GameObject> fillerClones = new List<GameObject>();
    List<GameObject> allCubeClones = new List<GameObject>();
    float fillerX = 0;
    float fillerY = 0;
    float fillerZ = 0;
    int selectedNum = 0;
    enum FillMode {
        Plane, Row, Point, Empty
    };
    FillMode fillMode;
    bool inMenu = true;

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

        currentObject = Instantiate(cube);
        currentObject.transform.SetParent(parent.transform);
        currentObject.SetActive(true);
        clones.Add(currentObject);
        allCubeClones.Add(currentObject);

        currentObject.GetComponent<Renderer>().material.color = Color.yellow;
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
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
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

        if (Input.GetKeyDown (KeyCode.Delete)) {
            foreach (var cube in allCubeClones) {
                Vector3 cubePos = cube.transform.position;
                foreach (var f in fillerClones) {
                    if (f.transform.position == cubePos) {
                        Destroy(cube);
                    }
                }
                allCubeClones.Remove(cube);
            }
        }

		if (Input.GetKeyDown (KeyCode.Escape)) {
            if (inMenu) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;

                EscMenu.gameObject.SetActive(true);
                ShownMenu.gameObject.SetActive(false);
                inMenu = false;
            } else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;

                EscMenu.gameObject.SetActive(false);
                ShownMenu.gameObject.SetActive(true);
                inMenu = true;
            }
		}
	}
}
