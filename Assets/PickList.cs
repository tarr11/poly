using UnityEngine;
using System.Collections;
using System.Linq;


public class PickList : MonoBehaviour {

	public float RotateSpeed = 10f;
	public GameObject DefaultCube;
	public GameObject DefaultPoly;


	// Use this for initialization
	void Start () {
		Poly.LoadPolysFromDirectory (this.gameObject, this.DefaultPoly, this.DefaultCube);

	}
	
	// Update is called once per frame
	void Update () {
		var cubes = GameObject.FindGameObjectsWithTag ("PickListObject");
		cubes.ToList ().ForEach (s => s.transform.Rotate (Vector3.up, RotateSpeed * Time.deltaTime));

		//test.transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
	}
}
