using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> musicPrefabs;

    int outputValue;
    void Start()
    {
        // Add enemy prefabs to the list
        float valueDeffuzifikasi = PlayerPrefs.GetFloat("result_deffuzifikasi");
        if (valueDeffuzifikasi <= 9.5)
        {
            outputValue = 0;
        }
        else if (valueDeffuzifikasi > 9.5 && valueDeffuzifikasi <= 11.0)
        {
            outputValue = 1;
        }
        else if (valueDeffuzifikasi > 11.0)
        {
            outputValue = 2;
        }

        ActivateGameObjects(outputValue);
    }

    private void ActivateGameObjects(int numToActivate)
    {
        if (numToActivate < musicPrefabs.Count)
        {
            // Deactivate all game objects
            musicPrefabs[numToActivate].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Invalid number of game objects to activate.");
            return;
        }
    }
}
