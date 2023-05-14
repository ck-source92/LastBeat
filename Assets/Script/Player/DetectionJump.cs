using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJump : MonoBehaviour
{
    [SerializeField] GameObject markerPrefab;

    int jumpCountLevel1 = 0;
    int jumpCountLevel2 = 0;
    void Start()
    {
        jumpCountLevel1 = 0;
        jumpCountLevel2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(markerPrefab, transform.position, Quaternion.identity);
        }

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
