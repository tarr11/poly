using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject Parent;
    public GameObject Cube;
	public GameObject DefaultEntry;
	public GameObject ParentContent;
   

	// Use this for initialization
	void Start () {
		var path = Application.persistentDataPath;
		var files = Directory.GetFiles (path, "*.gd");
		int index = 0;
		files.ToList ().ForEach ((s) => {
			var poly_entry = GameObject.Instantiate<GameObject>(this.DefaultEntry);
			var poly = GetPolyFromPath(s);

			poly_entry.transform.SetParent(ParentContent.transform, true);
			poly_entry.SetActive(true);
			poly_entry.transform.localScale = new Vector3(1, 1, 1);

			//poly_entry.transform.Translate(new Vector3(0, -30, 0));
			poly_entry.transform.localPosition += new Vector3(0, -30 * index, 0);
			//poly_entry.transform.Translate(Vector3.down);
			//poly_entry.transform.Translate(new Vector3(0, -1, 0));
			//poly_entry.transform.position  = new Vector3(0, 0, 0);
			var cs = poly_entry.GetComponentInChildren<Text>();
			cs.text = poly.Name;
//			text.text = s;
			index++;
		

		});
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Poly GetPolyFromPath (string path){
		using (var reader = new StreamReader (path)) {
			var json = reader.ReadToEnd ();
			var poly = JsonUtility.FromJson<Poly>(json);
			//poly.PopulateGameObject (Parent, Cube);
			return poly;
		}


	}

    public void OnClick() {
        //var p = Poly.MakeFakePoly();
        //p.PopulateGameObject(Parent, Cube);
        //p.transform.Translate ()
    }
}
                                                