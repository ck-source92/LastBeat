using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJump : MonoBehaviour
{
    int jumpCountLevel1 = 0;
    int jumpCountLevel2 = 0;

    // Update is called once per frame
    void Update()
    {
        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Level1:
                if (Input.GetMouseButtonDown(0))
                {
                    jumpCountLevel1 += 1;
                    PlayerPrefs.SetInt("amount_level_one_jump", jumpCountLevel1);
                }
                break;

            case Loader.Scene.Level2:
                if (Input.GetMouseButtonDown(0))
                {
                    jumpCountLevel2 += 1;
                    PlayerPrefs.SetInt("amount_level_two_jump", jumpCountLevel2);
                }
                break;
        }
    }
}
