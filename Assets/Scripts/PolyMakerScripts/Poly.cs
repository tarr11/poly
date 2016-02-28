using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[Serializable]
public class Poly  {

	public List<PolyPart> Parts;// = new List<PolyPart>();
    public string Name;
	public const int PolyScale = 50;
	public const int PolySize = 5;
    //public GameObject PolyModel;

    //private GameObject poly;
    //private GameObject PolyPart;

    public void PopulateGameObject(GameObject parent, GameObject cube) {
       

        foreach(var pp in Parts) {
            var part = GameObject.Instantiate<GameObject>(cube);
			part.transform.SetParent( parent.transform);
            part.transform.localPosition = pp.Position;
			part.transform.localScale = new Vector3 (1, 1, 1);
            part.SetActive(true);
        }

    }

	public static void LoadPolysFromDirectory(GameObject parentContent, GameObject defaultEntry, GameObject cube){
		var path = Application.persistentDataPath;
		var files = Directory.GetFiles (path, "*.gd");
		int index = 0;
		files.ToList ().ForEach ((s) => {
			var polyEntry = LoadPoly(s, parentContent, defaultEntry, cube);
			polyEntry.transform.localPosition += new Vector3(0, -1 * PolyScale * index - PolyScale, 0);
			index++;

		});

	}

	public static GameObject LoadPoly(string path, GameObject parentContent, GameObject defaultEntry, GameObject cube){
		var poly_entry = GameObject.Instantiate<GameObject>(defaultEntry);
		poly_entry.transform.localScale = new Vector3 (PolySize,PolySize,PolySize);
		poly_entry.tag = "PickListObject";
		var poly = Poly.GetPolyFromPath(path);

		poly_entry.transform.SetParent(parentContent.transform, true);
		poly_entry.SetActive(true);
		poly_entry.transform.localPosition = new Vector3 (-30, 100, -103);
		//poly_entry.transform.localScale = new Vector3(1, 1, 1);
		poly.PopulateGameObject (poly_entry, cube);
		return poly_entry;
	}

	public static Poly GetPolyFromPath (string path){
		using (var reader = new StreamReader (path)) {
			var json = reader.ReadToEnd ();
			var poly = JsonUtility.FromJson<Poly>(json);
			return poly;
		}


	}
    

}


[Serializable]
public class PolyPart {
    public Vector3 Position;

}