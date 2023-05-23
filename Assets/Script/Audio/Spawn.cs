using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public GameObject spawnPrefab1;
    public GameObject spawnPrefab2;
    public GameObject spawnPrefab3;
    void Start()
    {
        // Add enemy prefabs to the list
        enemyPrefabs.Add(spawnPrefab3);
        enemyPrefabs.Add(spawnPrefab2);
        enemyPrefabs.Add(spawnPrefab1);

        int outputValue = 1; // The output value you have

        ActivateGameObjects(outputValue);
    }

    void ActivateGameObjects(int numToActivate)
    {
        // Activate the specified number of game objects
        for (int i = 0; i < numToActivate; i++)
        {
            if (i < enemyPrefabs.Count)
            {
                enemyPrefabs[i].SetActive(true);
            }
            else
            {
                Debug.LogWarning("Not enough enemy prefabs in the list.");
                break;
            }
        }
    }
}
