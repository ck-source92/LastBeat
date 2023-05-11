using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJump : MonoBehaviour
{
    int jumpCount = 0;
    void Start()
    {
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Level1:
                if (Input.GetMouseButtonDown(0))
                {
                    jumpCount += 1;
                }
                break;

            case Loader.Scene.Level2:
                if (Input.GetMouseButtonDown(0))
                {
                    jumpCount += 1;
                }
                break;
        }

    }
}
