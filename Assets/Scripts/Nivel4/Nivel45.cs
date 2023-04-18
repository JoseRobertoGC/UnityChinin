using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Nivel45 : MonoBehaviour
{
    public List<Sprite> listaFiguraFraccion;
    public List<Sprite> listaFraccion;
    private GameObject figuraFraccionPrefab;
    private GameObject fraccionPrefab;

    private Image imagenAnterior;
    private List<Image> imagenesSeleccionadas = new List<Image>();
    private Sprite spriteAnterior;

    // Este método se llama cuando el usuario hace clic en una imagen
    public void SeleccionarImagen(Image imagenSeleccionada)
    {
        Debug.Log("Boton Presionado");
        Debug.Log(imagenSeleccionada.sprite.name);
        if (imagenSeleccionada == null)
        {
            Debug.Log("Imagen seleccionada es null");
            return;
        }
        Seleccion seleccionActual = imagenSeleccionada.GetComponent<Seleccion>();

        if (seleccionActual == null)
        {
            Debug.Log("La imagen seleccionada no tiene el componente Seleccion adjunto");
            return;
        }

        if (seleccionActual.EstaSeleccionado()) 
        {
            // Si la imagen ya está seleccionada, deseleccionarla
            seleccionActual.Deseleccionar();
            imagenesSeleccionadas.Remove(imagenSeleccionada);
        }
        else
        {
            // Seleccionar la imagen
            seleccionActual.Seleccionar();
            imagenesSeleccionadas.Add(imagenSeleccionada);

            // Verificar si ya hay una imagen anterior seleccionada
            if (imagenAnterior != null)
            {
                // Obtener el script "Seleccion" de ambas imágenes
                Seleccion seleccionAnterior = imagenAnterior.GetComponent<Seleccion>();

                // Verificar si las imágenes son combinables
                if (seleccionAnterior.Combinable(seleccionActual.sprite))
                {
                    // Dibujar una línea entre las imágenes
                    // Eliminar las imágenes
                    Debug.Log("Combinables");
                    Destroy(imagenSeleccionada);
                    Destroy(imagenAnterior);
                }
                else
                {
                    // Si no son combinables, deseleccionar la imagen anterior
                    seleccionAnterior.Deseleccionar();
                    seleccionActual.Deseleccionar();
                    imagenesSeleccionadas.Remove(imagenAnterior);
                    Debug.Log("No combinables");
                }
                // Reiniciar la variable imagenAnterior
                imagenAnterior = null;
            }
            else
            {
                // Si no hay una imagen anterior seleccionada, almacenar la imagen actual
                imagenAnterior = imagenSeleccionada;
            }

            // Almacenar el sprite de la imagen seleccionada en la variable "spriteAnterior"
            spriteAnterior = seleccionActual.sprite;
        }
    }

    private void Start()
    {
        // Buscar todas las imágenes en la escena
        Image[] images = FindObjectsOfType<Image>();
        Debug.Log("Cantidad de imágenes encontradas: " + images.Length);

        // Asignar sprites según el nombre de la imagen
        foreach (Image image in images)
        {
            if (image.name == "figuraFraccion")
            {
                // Escoger un sprite aleatorio de la lista de figuras de fracciones
                int index = Random.Range(0, listaFiguraFraccion.Count);
                image.sprite = listaFiguraFraccion[index];
                Debug.Log(image.sprite.name);
            }
            else if (image.name == "fraccion")
            {
                // Escoger un sprite aleatorio de la lista de fracciones
                int index = Random.Range(0, listaFraccion.Count);
                image.sprite = listaFraccion[index];
                Debug.Log(image.sprite.name);
            }
        }
    }
}
