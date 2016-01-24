using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour {


	public Text Console;
	public Text PolyCount;
	public InputField input;



	void Start ()
	{



		var se = new InputField.SubmitEvent();
		se.AddListener(ProcessCommand);
		input.onEndEdit = se;
	
		Console.text = "Poly Maker v1.0.0 loaded.";
		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}

	void Update()
	{
		//if (Input.GetKeyDown (KeyCode.Tab)) {

		//	input.ActivateInputField();
		//	Console.text = "ACTIVE";
		//}

	}

	private void ProcessCommand(string text)
	{

		input.text = "";
	
		//PolyCount.text = Cube.GetComponent<MeshFilter> ().sharedMesh.vertexCount + " Polys";
	
		Console.text += ">" + text + "\n";
		if (text == "maker") {
			Application.LoadLevel("maker");
		}
		if (text == "help") {
			Console.text += "HELP GOES HERE\n";

		} else {
			Console.text += "NO\n";
		}
        if (text == "start") {
            Application.LoadLevel("world");
        }



		//var clone = Instantiate (Cube);
		//clone.transform.position = new Vector3 (Cube.transform.position.x, Cube.transform.position.y + 1, Cube.transform.position.z);

	}
}
