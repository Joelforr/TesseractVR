using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tersseract2 : MonoBehaviour {
     public Color ObjectColor;
 
     private Color currentColor;
     private Material materialColored;
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ObjectColor != currentColor)
         {
             //helps stop memory leaks
             if (materialColored != null)
                 UnityEditor.AssetDatabase.DeleteAsset(UnityEditor.AssetDatabase.GetAssetPath(materialColored));
 
             //create a new material
             materialColored = new Material(Shader.Find("Diffuse"));
             materialColored.color = currentColor = ObjectColor;
             this.GetComponent<Renderer>().material = materialColored;
         }

		transform.Rotate(Vector3.left * 10f);
		transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
	}
}
