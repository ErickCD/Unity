using System.Collections;
using UnityEngine;

public class objectVertex{
    //vector de la cantidad de lugares a llegar.
    public Vector3[] VertTemp;
    //indice inicial para los triangulos
    public int indiceTemp;
    //Altura de cada vertice.
    public float[] alturasTemp;
    //grados que se recuerdan será 0 en caso de no haber.
    public float gradosTemp;

    //Constructor vacio para crear el objetos sin necesidad de llenarlos.
    public objectVertex(){}

    //Constructuctor que hace el trabajo
    public objectVertex(Vector3[] vertices, int indice, float[] alturas, float grados){
        VertTemp = vertices;
        indiceTemp = indice;
        alturasTemp = alturas;
        gradosTemp = grados;
    }

}
