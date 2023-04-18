using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarObjeto : MonoBehaviour
{
    public List<GameObject> listaObjetos;
    public List<GameObject> objetos3D;

    void Start()
    {
        // Seleccionar dos objetos 3D al azar de la lista
        int indiceAleatorio = Random.Range(0, listaObjetos.Count);

        // Reemplazar los dos objetos 3D seleccionados al azar
        for (int i = 0; i < 2; i++)
        {
            Vector3 posicion = objetos3D[i].transform.localPosition;
            Quaternion rotacion = objetos3D[i].transform.rotation;
            Vector3 escala = objetos3D[i].transform.localScale;

            // Guardar la posición actual del objeto antes de destruirlo
            objetos3D[i].GetComponent<Objeto3D>().posicionActual = posicion;

            GameObject objetoNuevo = Instantiate(listaObjetos[indiceAleatorio], posicion, rotacion);
            objetoNuevo.transform.SetParent(transform, false);
            objetoNuevo.transform.localScale = escala;
            Destroy(objetos3D[i]);
        }
    }
}
