@ -4,32 +4,21 @@ using UnityEngine;


public class Tesseract : MonoBehaviour {
<<<<<<< HEAD
     public Color ObjectColor;
 
     private Color currentColor;
     private Material materialColored;
=======
>>>>>>> parent of 413bd33... commit

	// Use this for initialization
	void Start () {
		Debug.Log("Start... :)");
	
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
		// Rigidbody rb = GetComponent<Rigidbody>();
		// rb.AddForce(Vector3.up * 10f);
		transform.Rotate(Vector3.right * 10f);
		transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
		
	}
}