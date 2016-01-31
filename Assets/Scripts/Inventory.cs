using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public GameObject Parent;
    public GameObject Cube;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick() {
        var p = Poly.MakeFakePoly();
        p.PopulateGameObject(Parent, Cube);
        //p.transform.Translate ()
    }
}
                                                