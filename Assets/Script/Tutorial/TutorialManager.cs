using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] popUpTextTutorial;
    private int popUpIndex;

    void Update()
    { 
        for (int i = 0; i < popUpTextTutorial.Length; i++)
        {
            if (popUpIndex == i)
            {
                popUpTextTutorial[i].SetActive(true);
            }
            else
            {
                popUpTextTutorial[i].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popUpIndex++;
        }
    }
}
