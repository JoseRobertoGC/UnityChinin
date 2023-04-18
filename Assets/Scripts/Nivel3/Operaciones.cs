using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Operaciones : MonoBehaviour
{
    private List<string> operadores = new List<string> {"suma","resta","division","multiplicacion"};
    private string operador;

    private TextMeshProUGUI textoOperador;
    private TextMeshProUGUI textoNumero;
    private TextMeshProUGUI textoResultado;

    private int valorBrick;
    private int respuesta = -100;

    public void SetInputText(string inputText)
    {
        respuesta = int.Parse(inputText);
    }

    private void Start()
    {
        textoOperador = transform.Find("Operator").GetComponent<TextMeshProUGUI>();
        textoNumero = transform.Find("Value").GetComponent<TextMeshProUGUI>();
        textoResultado = transform.Find("Result").GetComponent<TextMeshProUGUI>();

        int indiceAleatorio = Random.Range(0, operadores.Count);
        operador = operadores[indiceAleatorio];

        if (operador == "suma")
        {
            textoOperador.text = "+";
            valorBrick = Random.Range(0, 100);
            int valorNumero = Random.Range(0, 100);
            textoNumero.text = valorNumero.ToString();
            int resultado = valorBrick + valorNumero;
            textoResultado.text = resultado.ToString();
        }
        else if (operador == "resta")
        {
            textoOperador.text = "-";
            valorBrick = Random.Range(0, 100);
            int valorNumero = Random.Range(0, 100);
            textoNumero.text = valorNumero.ToString();
            int resultado = valorBrick - valorNumero;
            textoResultado.text = resultado.ToString();
        }
        else if (operador == "division")
        {
            textoOperador.text = "÷";
            valorBrick = Random.Range(0, 100);
            int valorNumero = Random.Range(1, 100); // Evita dividir por cero
            textoNumero.text = valorNumero.ToString();
            int resultado = valorBrick / valorNumero;
            textoResultado.text = resultado.ToString();
        }
        else if (operador == "multiplicacion")
        {
            textoOperador.text = "x";
            valorBrick = Random.Range(0, 100);
            int valorNumero = Random.Range(0, 100);
            textoNumero.text = valorNumero.ToString();
            int resultado = valorBrick * valorNumero;
            textoResultado.text = resultado.ToString();
        }
    }

    private void Update()
    {
        if(respuesta >= 0)
        {
            Debug.Log(valorBrick);
            if(respuesta == valorBrick)
            {
                Debug.Log("Respuesta Correcta");
                respuesta = -100;
            } else{
                Debug.Log("Respuesta Incorrecta");
            }
        } 
    }
}
