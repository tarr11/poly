using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject Cube;
	public Text Console;
	public Text PolyCount;

	void Start ()
	{

		var input = gameObject.GetComponent<InputField>();

		var se = new InputField.SubmitEvent();
		se.AddListener(ProcessCommand);
		input.onEndEdit = se;
	
		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}
	
	private void ProcessCommand(string text)
	{
		var input = gameObject.GetComponent<InputField>();
		input.text = "";
	
		PolyCount.text = Cube.GetComponent<MeshFilter> ().sharedMesh.vertexCount + " Polys";
	
		Console.text += ">" + text + "\n";
		if (text == "help") {
			Console.text += "HELP GOES HERE\n";

		} else {
			Console.text += "NO\n";
		}



		//var clone = Instantiate (Cube);
		//clone.transform.position = new Vector3 (Cube.transform.position.x, Cube.transform.position.y + 1, Cube.transform.position.z);

	}
}
