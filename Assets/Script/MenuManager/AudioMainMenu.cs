using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMainMenu : MonoBehaviour
{
    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<AudioMainMenu>().Length;
        if (numberScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    public void ResetAudioMainMenu()
    {
        Destroy(gameObject);
    }
}
