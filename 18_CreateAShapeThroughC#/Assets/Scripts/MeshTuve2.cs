using System.Collections;
using UnityEngine;

public class MeshTuve2 : MonoBehaviour {

	void Start ()
    {
        #region Declaraciones
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        float height = 1f;
        int nbSides = 32;

        float radius = 1f;

        int nbVerticesSides = nbSides * 2 + 2;
        #endregion

        #region vertices
        //Array to all the vector's points
        Vector3[] vertices = new Vector3[nbVerticesSides];
        //The number of vector
        int vert = 0;
        float _2pi = Mathf.PI * 2;

        //Sides
        int sideCounter = 0;
        while (vert < nbVerticesSides)
        {
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);

            vertices[vert] = new Vector3(cos * (radius * .5f), height, sin*(radius * .5f));
            //print(vertices[vert]);
            vertices[vert + 1] = new Vector3(cos * (radius * .5f), 0, sin*(radius * .5f));
            //print(vertices[vert + 1]);
            vert += 2;
        }
        #endregion

        #region triangles
        int nbfaces = nbSides;
        //Each face have a two triangles
        int nbTriangles = nbfaces * 2;
        //Each triangle have 3 vertex
        int nbIndex = nbTriangles * 3;

        //Arary to vertex
        int[] triangles = new int[nbIndex];

        //Only a counters
        int i = 0;
        sideCounter = 0;


        while(sideCounter < nbSides){
            int concurrent = sideCounter * 2;
            int next = sideCounter * 2 + 2;

            triangles[i++] = concurrent;
            //print(triangles[i - 1]);
            triangles[i++] = next;
            //print(triangles[i - 1]);
            triangles[i++] = next + 1;
            //print(triangles[i - 1]);
            triangles[i++] = concurrent;
            //print(triangles[i - 1]);
            triangles[i++] = next + 1;
            //print(triangles[i - 1]);
            triangles[i++] = concurrent + 1;
            //print(triangles[i - 1]);

            sideCounter++;
        }
        #endregion

        #region Normals
        sideCounter = 0;
        Vector3 [] normals = new Vector3[vertices.Length];
        vert = 0;

        while(vert < nbVerticesSides){
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++)/ nbSides * _2pi;
            normals[vert] = new Vector3(Mathf.Cos(r1), 0f, Mathf.Sin(r1));
            normals[vert + 1] = normals[vert];
            vert += 2;
        }

        #endregion

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
    }
}
