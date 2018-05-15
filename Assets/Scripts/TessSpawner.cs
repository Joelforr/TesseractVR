using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessSpawner : MonoBehaviour {

    public GameObject tesseractPrefab;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 500; i += 100)
        {
            for(int j = 0; j < 5; j++)
            Instantiate(tesseractPrefab, new Vector3(i, 30, (500/5)*j), Quaternion.identity);
        }

    }
	

}
