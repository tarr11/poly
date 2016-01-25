using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    //private Scene inventory = SceneManager.GetSceneByName("inventory");

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
