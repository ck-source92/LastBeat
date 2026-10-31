using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPersist : MonoBehaviour
{
    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<ScreenPersist>().Length;
        if (numberScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
