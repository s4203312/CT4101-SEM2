using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    Mesh mesh;

    private void Awake()
    {
        mesh = new Mesh();
        mesh.name = "MyQuad";
        GetComponent<MeshFilter>().sharedMesh = mesh;
    }

    private void Update() => Generate();    //Pass generate every frame

    public void Generate()
    {
        //Defining vertices
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(1,0,1),
            new Vector3(-1,0,1),
            new Vector3(1,0,-1),
            new Vector3(-1,0,-1),
        };
        //Defining normals
        Vector3[] normals = new Vector3[]
        {
            new Vector3(0,1,0),
            new Vector3(0,1,0),
            new Vector3(0,1,0),
            new Vector3(0,1,0),
        };
        //Defining UV's
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
        };
        //Defining triangles
        int[] triangles = new int[]
        {
            0, 2, 3,
            0, 3, 1
        };
        //Drawing Mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }
}
