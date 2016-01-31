using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public GameObject player;
    Vector3 offset;
    public Text polyparts;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
        polyparts.text = "PolyParts: " + polyparts;
	}
}
