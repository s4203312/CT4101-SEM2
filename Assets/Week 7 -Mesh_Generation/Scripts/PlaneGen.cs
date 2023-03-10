using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGen : MonoBehaviour
{
    Mesh mesh;

    //Planes sizes
    [Range(1, 10)] public int xSize;
    [Range(1, 10)] public int zSize;
    //Scaling
    [Range(0.1f, 10)] public float scale = 1;

    Vector3[] vertices;
    //Vector3[] normals;
    Vector2[] uvs;
    int[] triangles;

    private void Awake()
    {
        mesh = new Mesh();
        mesh.name = "MyPlane";
        GetComponent<MeshFilter>().sharedMesh = mesh;
    }

    private void Update() => Generate();

    void Generate() {

        //Defining Vertices
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];    //Array is length * width (including the ends)

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        //Defining Triangles
        triangles = new int[vertices.Length * 6];   //Amount of vertices * 6 (as there are 6 points in one square)

        int vert = 0, tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        //Defining UV's
        uvs = new Vector2[vertices.Length];     //Same amount of UV's as vertices

        for (int i = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                uvs[i] = new Vector2(x/(float)xSize, z/(float)zSize);
                i++;
            }

        }

        //Drawing Mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        //Scaling
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] *= scale;
        }
    }

    //Drawing gizmos on screen
    private void OnDrawGizmosSelected()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}