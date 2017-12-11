using System.Collections;
using UnityEngine;

public class newTuve : MonoBehaviour {

    public int cantidadDeCapas = 4;

    //Objeto reutilizable
    private objectVertex objetoVertice;
    Vector3[] vertices;
    float[] alturas;
    //Lista para guardar vertices
	ArrayList listaDeVertices = new ArrayList();

    int contadorDeListaObjeto = 0, vert = 0, nbSides = 32;
    int nbVerticesSides;
    float radius = 3f;
    float _2pi = Mathf.PI * 2;
    int sideCounter = 0;
    float gradosTotales = 0f;

    //Necesario que sea global
    MeshFilter filter;
    Mesh mesh;

    void Start () {
        #region Declaraciones
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;
        mesh.Clear();

        nbVerticesSides = nbSides + 1;

        //Ya que solo es una ilera de 32 sensores 1 más para la unión de los vertices.
        #endregion

        #region vertices
        //Array to all the vector's points
        vertices = new Vector3[nbVerticesSides];
        alturas = new float[nbVerticesSides];
        //The number of vector
        vert = 0;
        

        //Sides
        sideCounter = 0;
        while (vert < nbVerticesSides)
        {
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);
            //radius = Random.Range(0.9f, 1.1f);

            Vector3 r2 = new Vector3(cos * (radius), contadorDeListaObjeto, sin * (radius));
            vertices[vert] = r2;
            alturas[vert] = r2.y;
            //print("vertice: " + vertices[vert]);
            vert += 1;
        }
        
        listaDeVertices.Add(new objectVertex(vertices, contadorDeListaObjeto++, alturas, 0f));
        #endregion

        int contadorDeAgregarCapas = 0;
        float x = 6f;
        bool uno = true, dos = false, tres = false;
        while (contadorDeAgregarCapas < cantidadDeCapas){
			/*
            if (uno){
                capaCurva(0f);
                uno = contadorDeAgregarCapas == 10 ? false : true;
                dos = uno == false ? true : false;
            } else if (dos) {
                capaCurva(x);
                dos = contadorDeAgregarCapas == 26 ? false : true;
                tres = dos == false ? true : false;
            } else if (tres) {
                capaCurva(0f);
            }
			*/
			//Temporal

			if (uno){
				radius = 3f;
				capaCurva(0f);
				uno = contadorDeAgregarCapas <= 100 ? false : true;
				dos = uno == false ? true : false;
			} else if (dos) {
				radius = 3.2f;
				capaCurva(0f);
				dos = contadorDeAgregarCapas == 150 ? false : true;
				tres = dos == false ? true : false;
			} else if (tres) {
				radius = 2.8f;
				capaCurva(0f);
				tres = contadorDeAgregarCapas == 200 ? false : true;
				uno = tres == false ? true : false;
			}
				
            contadorDeAgregarCapas++;
        }

        fin();
    }

    //===============================================================================
    //CapaCurvada

    public void capaCurva(float angulo){
        //gradosTotales = angulo > 0 ? gradosTotales + angulo : gradosTotales - angulo;
        gradosTotales = gradosTotales + angulo;

        vertices = new Vector3[nbVerticesSides];
        //Guarda nuevas alturas
        alturas = new float[nbVerticesSides];
        float alturaActual = 0.01f;

        if (gradosTotales >= 112.5f)
        {
            alturaActual = -.50f;
        }
        else if (gradosTotales == 90f)
        {
            alturaActual = 0f;
        }
        else if (gradosTotales >= 90f)
        {
            alturaActual = alturaActual - .25f;
        }
        else if (gradosTotales >= 67.5f)
        {
            alturaActual = alturaActual + .25f;
        }
        else if (gradosTotales >= 45f)
        {
            alturaActual = alturaActual + 0.5f;
        }
        else if (gradosTotales >= 22.5f)
        {
            alturaActual = alturaActual + 0.75f;
        }
        else if (gradosTotales >= 0)
        {
            alturaActual = alturaActual + 0.01f;
        }

        print("Grados totales son: " + gradosTotales + " y la altura es: " + alturaActual);

        vert = 0;

        //recuerda la alturas anteriores
        float[] alturasAnteriores = ((objectVertex)listaDeVertices[contadorDeListaObjeto - 1]).alturasTemp;
        //Recuerda grado anterior 0°
        //float grados = ((objectVertex)listaDeVertices[contadorDeListaObjeto - 1]).gradosTemp;
        //print("Grados anteriores vale: " + grados);
        //grados = grados + angulo;
        //print("Grados después de la suma vale: " + grados);

        int sideCounter = 0;
        while (vert < nbVerticesSides)
        {
            sideCounter = sideCounter == nbSides ? 0 : sideCounter;

            //radius = Random.Range(2.95f, 3.1f);

            float r1 = (float)(sideCounter++) / nbSides * _2pi;
            float cos = Mathf.Cos(r1);
            float sin = Mathf.Sin(r1);

            

            Vector3 vertice1 = new Vector3(cos * (radius), (alturasAnteriores[vert] + alturaActual), sin * (radius));
            //print("Vertice1 vale: " + vertice1);
            //Vector3 r2 = Quaternion.AngleAxis(25, Vector3.up) * new Vector3(Mathf.Sin(r1), Mathf.Cos(r1));
            //Vector3 r2 = grados < 0 ? (Quaternion.AngleAxis(grados, Vector3.up) * vertice1) :( Quaternion.AngleAxis(grados, Vector3.left) * vertice1);
            Vector3 r2 = Quaternion.AngleAxis(-angulo, Vector3.left  ) * vertice1;
            //print("Vertice vale: " + r2);
            vertices[vert] = r2;
            alturas[vert] = r2.y;
            vert += 1;
        }
        listaDeVertices.Add(new objectVertex(vertices, contadorDeListaObjeto++, alturas, angulo));
    }

    //===============================================================================

    #region no se utiliza por el momento
    //public void AgregaNuevaCapa(){
    //    //Array to all the vector's points
    //    vertices = new Vector3[nbVerticesSides];
    //    alturas = new float[nbVerticesSides];
    //    //The number of vector
    //    vert = 0;
    //    //Recordando alturas anteriores
    //    float[] alturasAnteriores = ((objectVertex)listaDeVertices[contadorDeListaObjeto - 1]).alturasTemp;

    //    int sideCounter = 0;
    //    while (vert < nbVerticesSides){
    //        sideCounter = sideCounter == nbSides ? 0 : sideCounter;

    //        //radius = Random.Range(0.9f, 1.1f);
    //        float r1 = (float)(sideCounter++) / nbSides * _2pi;
    //        float cos = Mathf.Cos(r1);
    //        float sin = Mathf.Sin(r1);
    //        Vector3 r2 = new Vector3(cos * (radius), (alturasAnteriores[vert] + 1), sin * (radius));
    //        vertices[vert] = r2;
    //        //print("Vertice: " + vertices[vert]);
    //        alturas[vert] = r2.y;
    //        vert += 1;
    //    }
    //    listaDeVertices.Add(new objectVertex(vertices, contadorDeListaObjeto++, alturas, 0f));
    //}
    #endregion

    public void fin()
    {
        //El vector de vertices completos, procesa la cantidad de capas necesarias.
        Vector3[] verticesCompletos = new Vector3[(nbSides + 1) * contadorDeListaObjeto];

        int countVertComp = 0;
        while (countVertComp < contadorDeListaObjeto)
        {
            (((objectVertex)listaDeVertices[countVertComp]).VertTemp).CopyTo(verticesCompletos, (countVertComp++ * (nbSides + 1)));
        }

        #region triangles
        int nbfaces = nbSides * contadorDeListaObjeto;
        //Each face have a two triangles
        int nbTriangles = nbfaces * 2;
        //Each triangle have 3 vertex
        int nbIndex = nbTriangles * 3;

        //Arary to vertex
        int[] triangles = new int[nbIndex];

        //Only a counters
        int countTriagles = 0;
        int countPlant = 0;

        
        int indice = ((objectVertex)listaDeVertices[countPlant]).indiceTemp;
        int indiceSig = (nbSides + 1) + indice;


        while (countPlant < (listaDeVertices.Count  -1))
        {

            //Impresiones para comprobar el correcto uso de los indices.
            //print("indice: " + indice);
            //print("indiceAct: " + indiceSig);

            sideCounter = 0;

            #region whileInterno
            while (sideCounter < nbSides)
            {

                triangles[countTriagles++] = indiceSig;
                //print(triangles[countTriagles - 1]);
                triangles[countTriagles++] = indiceSig + 1;
                //print(triangles[countTriagles - 1]);
                triangles[countTriagles++] = indice + 1;
                //print(triangles[countTriagles - 1]);
                triangles[countTriagles++] = indiceSig;
                //print(triangles[countTriagles - 1]);
                triangles[countTriagles++] = indice + 1;
                //print(triangles[countTriagles - 1]);
                triangles[countTriagles++] = indice;
                //print(triangles[countTriagles - 1] + "\n");

                sideCounter++;
                indice++;
                indiceSig++;
            }
            #endregion

            indice ++;
            indiceSig ++;

            countPlant++;
        }

        
        #endregion

        mesh.vertices = verticesCompletos;
        mesh.triangles = triangles;
    }
}
