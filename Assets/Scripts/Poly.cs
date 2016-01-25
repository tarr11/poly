using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Poly : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frames
    void Update() {

    }

    public List<PolyPart> Parts = new List<PolyPart>();
    public string Name;
    //public GameObject PolyModel;

    //private GameObject poly;
    //private GameObject PolyPart;

    public void PopulateGameObject(GameObject parent, GameObject cube) {
       

        foreach(var pp in Parts) {
            var part = GameObject.Instantiate<GameObject>(cube);
            part.transform.parent = parent.transform;
            part.transform.position = pp.Position;
            part.SetActive(true);
        }

    }
    
    public static Poly MakeFakePoly() {
        Poly poly = new Poly();
        poly.Parts.Add(new PolyPart { Position = new Vector3(0, 0, 0) });
        return poly;
        //currentObject = (GameObject)Instantiate(cube, new Vector3(cube.transform.position.x, cube.transform.position.y + 2, cube.transform.position.z), cube.transform.rotation);
        //poly = (GameObject) Instantiate(PolyPart, new Vector3(PolyPart.transform.position.x, PolyPart.transform.position.y, PolyPart.transform.position.z), PolyPart.transform.rotation);
    }

}


[Serializable]
public class PolyPart {
    public Vector3 Position;

}