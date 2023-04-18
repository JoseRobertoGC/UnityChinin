using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prendas : MonoBehaviour
{
    private int prendasCount = 0;        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prenda"))
        {
            Destroy(collision.gameObject);
            prendasCount++;
            Debug.Log("Prenda encontrada! Total de prendas encontradas: " + prendasCount);
        }
    }
}
