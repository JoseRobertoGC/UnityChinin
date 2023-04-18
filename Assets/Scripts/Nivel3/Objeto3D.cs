using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto3D : MonoBehaviour
{
    public Vector3 posicionActual;

    private void Start()
    {
        // Obtener la posición actual del objeto
        posicionActual = transform.localPosition;
    }
}
