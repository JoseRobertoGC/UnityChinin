using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alimentos : MonoBehaviour
{
    private int alimentosCount = 0;      

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alimento"))
        {
            Destroy(collision.gameObject);
            alimentosCount++;
            Debug.Log("Alimentos encontrada! Total de alimentos encontradas: " + alimentosCount);
        }
    }
}
