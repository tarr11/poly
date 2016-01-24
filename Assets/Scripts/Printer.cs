using UnityEngine;
using System.Collections;
using System.Xml;

public class Printer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextAsset textAsset = (TextAsset)Resources.Load("MyXMLFile");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
