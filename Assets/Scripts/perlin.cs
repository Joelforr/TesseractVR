
using UnityEngine;

public class perlin : MonoBehaviour {

    public int w = 300;
    public int h = 300;
    public int d = 15;

	public void Start()
	{
       Terrain t = GetComponent<Terrain>();
        t.terrainData = createTerrain(t.terrainData);
	}


    TerrainData createTerrain( TerrainData x) {

        x.heightmapResolution = w + 1;
        x.size = new Vector3(w, d, h);
        x.SetHeights(0, 0, genheights());
        return x;
    }

    float[,] genheights() {
        float[,] newheight = new float[w, h];
        for (int i = 0; i < w; i++){
            for (int j = 0; j < h; j++){
                newheight[i, j] = getPerlin(i, j);
            }
        }

        return newheight;
    }

    float getPerlin(int i, int j){
        float xPos = (float)i / w * 25F;
        float yPos = (float)j / h * 25F;

        return Mathf.PerlinNoise(xPos, yPos);
    }
}
