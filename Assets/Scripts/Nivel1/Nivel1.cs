using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Nivel1 : MonoBehaviour
{
    public List<GameObject> figurePrefabs = new List<GameObject>();
    public GameObject backpackPrefab;
    public int totalFigures;
    public float xMin = -5f;
    public float xMax = 20f;
    public float yMin = 10f;
    public float yMax = 21f;
    public float zPos = 20f;
    public float minDistance = 3f;

    public int xSize = 5;
    public int ySize = 5;
    public float cellSize = 2f;

    private Vector3[] figurePositions;
    private Vector3[,] gridPositions;

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
        for (int i = 0; i < 3; i++)
        {
            GameObject backpack = Instantiate(backpackPrefab, cubePositions[i], Quaternion.Euler(90f, 0f, -180f));
        }

        // Generate the figures
        totalFigures = figurePrefabs.Count;
        figurePositions = new Vector3[totalFigures];
        gridPositions = new Vector3[xSize, ySize];

        int remainingFigures = totalFigures;
        int prefabIndex = 0;
        while (remainingFigures > 0)
        {
            int xIndex = Random.Range(0, xSize);
            int yIndex = Random.Range(0, ySize);
            Vector3 position = GetPositionFromGrid(xIndex, yIndex);
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

    Vector3 GetPositionFromGrid(int x, int y)
    {
        float xPos = x * cellSize + Random.Range(-cellSize / 2f, cellSize / 2f);
        float yPos = y * cellSize + Random.Range(-cellSize / 2f, cellSize / 2f);
        return new Vector3(xPos, yPos, zPos);
    }
}
