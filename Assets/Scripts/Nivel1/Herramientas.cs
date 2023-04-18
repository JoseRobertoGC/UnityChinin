using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herramientas : MonoBehaviour
{
    private int herramientasCount = 0;    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Herramienta"))
        {
            Destroy(collision.gameObject);
            herramientasCount++;
            Debug.Log("Herramienta encontrada! Total de herramientas encontradas: " + herramientasCount);
        }
    }
}
