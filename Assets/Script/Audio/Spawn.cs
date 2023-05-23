using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    List<GameObject> enemyPrefabs = new List<GameObject>();
    public GameObject spawnPrefab1;
    public GameObject spawnPrefab2;
    public GameObject spawnPrefab3;

    int outputValue;
    void Start()
    {
        // Add enemy prefabs to the list
        enemyPrefabs.Add(spawnPrefab1);
        enemyPrefabs.Add(spawnPrefab2);
        enemyPrefabs.Add(spawnPrefab3);

        float valueDeffuzifikasi = PlayerPrefs.GetFloat("result_deffuzifikasi");
        if (valueDeffuzifikasi <= 9.5)
        {
            outputValue = 1;
        }
        else if (valueDeffuzifikasi > 9.5 && valueDeffuzifikasi <= 11.0)
        {
            outputValue = 2;
        }
        else if (valueDeffuzifikasi > 11.0)
        {
            outputValue = 3;
        }

        ActivateGameObjects(outputValue);
    }

    private void ActivateGameObjects(int numToActivate)
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
