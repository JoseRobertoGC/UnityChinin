using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seleccion : MonoBehaviour
{
    private bool seleccionado = false;
    private Color colorOriginal;
    public Sprite sprite;

    public void Seleccionar()
    {
        // Cambiar el color de la imagen cuando se selecciona
        Image imagen = GetComponent<Image>();
        colorOriginal = imagen.color;
        imagen.color = Color.gray;
        sprite = imagen.sprite;

        // Indicar que la imagen está seleccionada
        seleccionado = true;
        Debug.Log("Seleccionado");
    }

    public void Deseleccionar()
    {
        // Restaurar el color original de la imagen
        GetComponent<Image>().color = colorOriginal;

        // Indicar que la imagen ya no está seleccionada
        seleccionado = false;
        Debug.Log("Deseleccionado");
    }

    public bool EstaSeleccionado()
    {
        // Devolver el valor de la variable seleccionado
        Debug.Log(seleccionado);
        return seleccionado;
        
    }

    public bool Combinable(Sprite spriteOtraImagen)
    {
        Debug.Log("Combinable: " + sprite.name + " " + spriteOtraImagen.name);
        // Devuelve true si los sprites son iguales, false en caso contrario
        return sprite.name == spriteOtraImagen.name;
    }
}
