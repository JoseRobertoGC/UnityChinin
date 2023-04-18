using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> figurePrefabs = new List<GameObject>();
    public GameObject backpackPrefabFood;
    public GameObject backpackPrefabClothes;
    public GameObject backpackPrefabTools;

    public int totalFigures;
    private float xMin = -5f;
    private float xMax = 20f;
    private float yMin = 10f;
    private float yMax = 21f;
    private float zPos = 20f;
    private float minDistance = 3f;

    private Vector3[] figurePositions;

    void Start()
    {
        // Generate the platform
        GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platform.transform.position = new Vector3(7.11f, 13f, 21f);
        platform.transform.localScale = new Vector3(30f, 20f, 0f);

        // Generate the cubes
        Vector3[] cubePositions = new Vector3[3];
        cubePositions[0] = new Vector3(2f, 6f, 20f);
        cubePositions[1] = new Vector3(7f, 6f, 20f);
        cubePositions[2] = new Vector3(12f, 6f, 20f);

        GameObject backpack1 = Instantiate(backpackPrefabFood, cubePositions[0], Quaternion.Euler(90f, 0f, -180f));
        GameObject backpack2 = Instantiate(backpackPrefabClothes, cubePositions[1], Quaternion.Euler(90f, 0f, -180f));
        GameObject backpack3 = Instantiate(backpackPrefabTools, cubePositions[2], Quaternion.Euler(90f, 0f, -180f));

        // Generate the figures
        totalFigures = figurePrefabs.Count;
        figurePositions = new Vector3[totalFigures];
        int remainingFigures = totalFigures;
        int prefabIndex = 0;
        while (remainingFigures > 0)
        {
            float xPos = Random.Range(xMin, xMax);
            float yPos = Random.Range(yMin, yMax);
            Vector3 position = new Vector3(xPos, yPos, zPos);
            bool tooClose = false;
            foreach (Vector3 otherPosition in figurePositions)
            {
                if (otherPosition != Vector3.zero && Vector3.Distance(position, otherPosition) < minDistance)
                {
                    tooClose = true;
                    break;
                }
            }
            if (!tooClose)
            {
                GameObject figurePrefab = figurePrefabs[prefabIndex];
                if (figurePrefab != null)
                {
                    GameObject figure = Instantiate(figurePrefab, position, Quaternion.identity);
                    figurePositions[totalFigures - remainingFigures] = position;
                    remainingFigures--;
                }
                prefabIndex = (prefabIndex + 1) % figurePrefabs.Count;
            }
        }
        Debug.Log("Total number of figures generated: " + totalFigures);
    }
}
