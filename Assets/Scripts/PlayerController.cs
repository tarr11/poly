using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public float Velo = 5;
    public float JumpHeight = 100;

    public bool isJump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey ("w")) {
            player.transform.Translate(Vector3.forward * Time.deltaTime * Velo);
        }
        if (Input.GetKey("a")) {
            player.transform.Translate(Vector3.left * Time.deltaTime * Velo);
        }
        if (Input.GetKey("s")) {
            player.transform.Translate(Vector3.back * Time.deltaTime * Velo);
        }
        if (Input.GetKey("d")) {
            player.transform.Translate(Vector3.right * Time.deltaTime * Velo);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false) {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpHeight);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.gameObject.tag == ("Ground")) {
            isJump = false;
        }
    }
}
