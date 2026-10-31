using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;
    private void Update()
    {
        if (!isFirstUpdate)
        {
            return;
        }

        Loader.LoaderCallback();
        isFirstUpdate = false;
    }
}
