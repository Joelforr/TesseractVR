using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingCube : MonoBehaviour {
     public Color ObjectColor;
 
     private Color currentColor;
     private Material materialColored;

	// Use this for initialization
	void Start () {
		Debug.Log("Start... :)");
	}
	
	// Update is called once per frame
	void Update () {
         if (ObjectColor != currentColor)
         {
 
             //create a new material
             materialColored = new Material(Shader.Find("Diffuse"));
             materialColored.color = currentColor = ObjectColor;
             this.GetComponent<Renderer>().material = materialColored;
         }
		// Rigidbody rb = GetComponent<Rigidbody>();
		// rb.AddForce(Vector3.up * 10f);

 		transform.Rotate(Vector3.right * 10f);
  		transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
	}
}
