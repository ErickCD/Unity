using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTuve : MonoBehaviour {

	void Start ()
    {
        #region Declaraciones

        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        float height = 1f;
        int nbSides = 6;

        // Outter shell is at radius1 + radius2 / 2, inner shell at radius1 - radius2 / 2
        float bottomRadius1 = .5f;
        float bottomRadius2 = .15f;
        float topRadius1 = .5f;
        float topRadius2 = .15f;

        int nbVerticesCap = nbSides * 2 + 2;
        int nbVerticesSides = nbSides * 2 + 2;

        #endregion

        #region Vertices

        // bottom + top + sides
        Vector3[] vertices = new Vector3[nbVerticesCap * 2 + nbVerticesSides * 2];

        int vert = 0;
        float _2pi = Mathf.PI * 2f;

        // Bottom cap
        print("Bottom cap");
        int sideCounter = 0;
        while (vert < nbVerticesCap)
        {
            //Impresion
            print("vert (" + vert + ") < nbverticesCap ( "+nbVerticesCap+")");
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);
            vertices[vert] = new Vector3(cos * (bottomRadius1 - bottomRadius2 * .5f), 0f, sin * (bottomRadius1 - bottomRadius2 * .5f));
            print(vertices[vert]);
            vertices[vert + 1] = new Vector3(cos * (bottomRadius1 + bottomRadius2 * .5f), 0f, sin * (bottomRadius1 + bottomRadius2 * .5f));
            print(vertices[vert+1]);
            vert += 2;
        }

        // Top cap
        sideCounter = 0;
        print("Top cap");
        while (vert < nbVerticesCap * 2)
        {
            //Impresion
            print("vert (" + vert + ") < nbverticesCap *2 ( " + nbVerticesCap * 2 + ")");
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);
            vertices[vert] = new Vector3(cos * (topRadius1 - topRadius2 * .5f), height, sin * (topRadius1 - topRadius2 * .5f));
            print(vertices[vert]);
            vertices[vert + 1] = new Vector3(cos * (topRadius1 + topRadius2 * .5f), height, sin * (topRadius1 + topRadius2 * .5f));
            print(vertices[vert+1]);
            vert += 2;
        }

        // Sides (out)
        sideCounter = 0;
        print("Sides out");
        while (vert < nbVerticesCap * 2 + nbVerticesSides)
        {
            print("vert (" + vert + ") < nbverticesCap * 2 ( " + nbVerticesCap * 2 + ") + nbverticesSides (" + nbVerticesSides + ")");
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);

            vertices[vert] = new Vector3(cos * (topRadius1 + topRadius2 * .5f), height, sin * (topRadius1 + topRadius2 * .5f));
            print(vertices[vert]);
            vertices[vert + 1] = new Vector3(cos * (bottomRadius1 + bottomRadius2 * .5f), 0, sin * (bottomRadius1 + bottomRadius2 * .5f));
            print(vertices[vert+1]);
            vert += 2;
        }

        // Sides (in)
        sideCounter = 0;
        print("Sides (in)");
        while (vert < vertices.Length)
        {
            print("vert (" + vert + ") < vertices.length ( " + vertices.Length + ")");
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);

            vertices[vert] = new Vector3(cos * (topRadius1 - topRadius2 * .5f), height, sin * (topRadius1 - topRadius2 * .5f));
            print(vertices[vert]);
            vertices[vert + 1] = new Vector3(cos * (bottomRadius1 - bottomRadius2 * .5f), 0, sin * (bottomRadius1 - bottomRadius2 * .5f));
            print(vertices[vert +1]);
            vert += 2;
        }
        #endregion

        #region Normales

        // bottom + top + sides
        Vector3[] normales = new Vector3[vertices.Length];
        vert = 0;

        // Bottom cap
        //print("Bottom cap");
        while (vert < nbVerticesCap)
        {
            normales[vert++] = Vector3.down;
            //print(normales[vert - 1]);
        }

        // Top cap
        //print("top cap");
        while (vert < nbVerticesCap * 2)
        {
            normales[vert++] = Vector3.up;
            //print(normales[vert - 1]);
        }

        // Sides (out)
        sideCounter = 0;
        print("Normal slide out");
        while (vert < nbVerticesCap * 2 + nbVerticesSides)
        {
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;

            normales[vert] = new Vector3(Mathf.Cos(r1), 0f, Mathf.Sin(r1));
            print(normales[vert]);
            normales[vert + 1] = normales[vert];
            print(normales[vert + 1]);
            vert += 2;
        }

        // Sides (in)
        sideCounter = 0;
        //print("Normal slide in");
        while (vert < vertices.Length)
        {
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;

            normales[vert] = -(new Vector3(Mathf.Cos(r1), 0f, Mathf.Sin(r1)));
            //print(normales[vert]);
            normales[vert + 1] = normales[vert];
            //print(normales[vert + 1]);
            vert += 2;
        }
        #endregion

        #region UVs
        Vector2[] uvs = new Vector2[vertices.Length];

        vert = 0;
        // Bottom cap
        sideCounter = 0;
        //print("Bottom cap");
        while (vert < nbVerticesCap)
        {
            float t = (float)(sideCounter++) / nbSides;
            uvs[vert++] = new Vector2(0f, t);
            //print(uvs[vert - 1]);
            uvs[vert++] = new Vector2(1f, t);
            //print(uvs[vert - 1]);
        }

        // Top cap
        sideCounter = 0;
        //print("Top cap");
        while (vert < nbVerticesCap * 2)
        {
            float t = (float)(sideCounter++) / nbSides;
            uvs[vert++] = new Vector2(0f, t);
            //print(uvs[vert - 1]);
            uvs[vert++] = new Vector2(1f, t);
            //print(uvs[vert - 1]);
        }

        // Sides (out)
        sideCounter = 0;
        //print("Slidesout");
        while (vert < nbVerticesCap * 2 + nbVerticesSides)
        {
            float t = (float)(sideCounter++) / nbSides;
            uvs[vert++] = new Vector2(t, 0f);
            //print(uvs[vert - 1]);
            uvs[vert++] = new Vector2(t, 1f);
            //print(uvs[vert - 1]);
        }

        // Sides (in)
        sideCounter = 0;
        //print("Slides in");
        while (vert < vertices.Length)
        {
            float t = (float)(sideCounter++) / nbSides;
            uvs[vert++] = new Vector2(t, 0f);
            //print(uvs[vert - 1]);
            uvs[vert++] = new Vector2(t, 1f);
            //print(uvs[vert - 1]);
        }
        #endregion

        #region Triangles
        int nbFace = nbSides * 4;
        int nbTriangles = nbFace * 2;
        int nbIndexes = nbTriangles * 3;
        int[] triangles = new int[nbIndexes];

        // Bottom cap
        int i = 0;
        sideCounter = 0;
        print("Triangles bottom cap");
        while (sideCounter < nbSides)
        {
            int current = sideCounter * 2;
            int next = sideCounter * 2 + 2;

            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = next;
            print(triangles[i - 1]);
            triangles[i++] = current;
            print(triangles[i - 1]);

            triangles[i++] = current + 1;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = current;
            print(triangles[ i - 1]);

            sideCounter++;
        }

        // Top cap
        print("Triangles top cap");
        while (sideCounter < nbSides * 2)
        {
            int current = sideCounter * 2 + 2;
            int next = sideCounter * 2 + 4;

            triangles[i++] = current;
            print(triangles[ i - 1]);
            triangles[i++] = next;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);

            triangles[i++] = current;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = current + 1;
            print(triangles[ i - 1]);

            sideCounter++;
        }

        // Sides (out)
        print("Triangles sides out");
        while (sideCounter < nbSides * 3)
        {
            int current = sideCounter * 2 + 4;
            int next = sideCounter * 2 + 6;

            triangles[i++] = current;
            print(triangles[ i - 1]);
            triangles[i++] = next;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);

            triangles[i++] = current;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = current + 1;
            print(triangles[ i - 1]);

            sideCounter++;
        }


        // Sides (in)
        print("Triangles sides in");
        while (sideCounter < nbSides * 4)
        {
            int current = sideCounter * 2 + 6;
            int next = sideCounter * 2 + 8;

            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = next;
            print(triangles[ i - 1]);
            triangles[i++] = current;
            print(triangles[ i - 1]);

            triangles[i++] = current + 1;
            print(triangles[ i - 1]);
            triangles[i++] = next + 1;
            print(triangles[ i - 1]);
            triangles[i++] = current;
            print(triangles[ i - 1]);

            sideCounter++;
        }
        #endregion

        mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        ;
	}
	
}
