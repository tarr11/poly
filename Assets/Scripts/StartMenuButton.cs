using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class StartMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		Application.LoadLevel ("welcome");
	}
}