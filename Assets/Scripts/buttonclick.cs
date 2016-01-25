using UnityEngine;
using System.Collections;

public class buttonclick : MonoBehaviour {

    public GameObject Inventory;
    public GameObject Cube;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick() {
        var p = Poly.MakeFakePoly();
        p.PopulateGameObject(Inventory, Cube);
    }
}
                                                