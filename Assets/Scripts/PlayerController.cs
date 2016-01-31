using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public GameObject inventory;
    public float Velo = 5;
    public float JumpHeight = 100;
    public float polyparts = 0;

    private bool isJump = false;
    private bool inv = false;

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
        if (Input.GetKeyDown("e")) {
            if (inv == false) {
                inventory.SetActive(true);
                inv = true;
                PauseGame();
            } else {
                inventory.SetActive(false);
                inv = false;
                PauseGame();
            }
            
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.gameObject.tag == ("Ground")) {
            isJump = false;
        }
    }

    public void PauseGame () {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }
}
