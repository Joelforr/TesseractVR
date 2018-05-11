using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]



public class Tesseract : MonoBehaviour {
    MeshFilter meshFilter;
    Mesh mesh;

    public Vector4[] p;                     //The vertex points for a tesseract
    Matrix4x4[] m = new Matrix4x4[6];

    public List<Vector3> verts;
    public List<int> tris;
    public List<Vector2> uvs;



    // Use this for initialization
    void Start () {

        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }

        p = new Vector4[]{
            new Vector4(1,1,1,1),               //A
            new Vector4(1,1,1,-1),              //B
            new Vector4(1,1,-1,1),              //C
            new Vector4(1,1,-1,-1),             //D
            new Vector4(1,-1,1,1),              //E
            new Vector4(1,-1,1,-1),             //F
            new Vector4(1,-1,-1,1),             //G
            new Vector4(1,-1,-1,-1),            //H
            new Vector4(-1,1,1,1),              //I
            new Vector4(-1,1,1,-1),             //J
            new Vector4(-1,1,-1,1),             //K
            new Vector4(-1,1,-1,-1),            //L
            new Vector4(-1,-1,1,1),             //M
            new Vector4(-1,-1,1,-1),            //N
            new Vector4(-1,-1,-1,1),            //O
            new Vector4(-1,-1,-1,-1)            //P
        };

        int[,] X = { { 6, 8, 1, 12, 7, 11 }, { 5, 0, 0, 0, 5, 10 }, { 10, 10, 5, 15, 15, 15 } };
        for (int i = 0; i < 6; i++)
        {
            m[i] = Matrix4x4.identity;
            float c = Mathf.Cos(.01f);
            float s = Mathf.Sin(.01f);
            m[i][X[1, i]] = c;
            m[i][X[2, i]] = c;
            m[i][X[0, i]] = s;
            m[i][X[0, i] % 4 * 4 + X[0, i] / 4] = -s;
        }
    }
	
	// Update is called once per frame
	void Update () {
        DrawTesseract();
	}

    void DrawTesseract()
    {
        mesh.Clear();
        verts = new List<Vector3>();
        tris = new List<int>();
        uvs = new List<Vector2>();

        for (int i = 0; i < 16; i++) foreach (Matrix4x4 x in m) p[i] = x * p[i];
        int[] F = { 0, 1, 9, 11, 10, 8, 9, 13, 15, 11, 3, 7, 15, 14, 10, 2, 6, 14, 12, 8, 0, 4, 12, 13, 5, 7, 6, 4, 5, 1, 3, 2, 0 };

        for (int i = 0; i < 33; i++){
            verts.Add(p[F[i]]);
            tris.Add(i);
        }

        mesh.vertices = verts.ToArray();
        mesh.SetTriangles(tris.ToArray(), 0);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        MeshUtility.Optimize(mesh);

    }

    void CreatePlane(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        Vector2 uv0 = Vector2.zero;
        Vector2 uv1 = Vector2.zero;
        Vector2 uv2 = Vector2.zero;


        List<Vector3> newVerts = new List<Vector3>(){
            p1,p3,p2,
            p1,p2,p4,
            p2,p3,p4,
            p1,p4,p3
        };

        verts.AddRange(newVerts);
        mesh.vertices = verts.ToArray();

        int t = tris.Count;
        for (int j = 0; j < 12; j++)
        {
            tris.Add(j + t);
        }

        mesh.SetTriangles(tris.ToArray(), 0);


        uv0 = new Vector2(0, 0);
        uv1 = new Vector2(1, 0);
        uv2 = new Vector2(0.5f, 1);

        uvs.AddRange(
            new List<Vector2>(){
                uv0,uv1,uv2,
                uv0,uv1,uv2,
                uv0,uv1,uv2,
                uv0,uv1,uv2
            }
        );
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        MeshUtility.Optimize(mesh);
    }
}
