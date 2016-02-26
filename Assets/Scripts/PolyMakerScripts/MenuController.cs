using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class MenuController : MonoBehaviour{

    public void Start() {

    }

    public void Update() {

    }

    public void CreatePoly() {
        var button = GameObject.Find("PolyParts");
        var pmaker = button.GetComponent<PolyMaker>();
        
        Poly p = new Poly();
        p.Name = pmaker.PolyName.text;
        p.Parts = pmaker.clones.Select(s => new PolyPart { Position = s.transform.position }).ToList();

        var json = JsonUtility.ToJson(p);

        using (var writer = new StreamWriter(Application.persistentDataPath + "/" + p.Name + ".gd")) {
            writer.Write(json);
        }
    }
}
