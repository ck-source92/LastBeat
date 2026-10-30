using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private Image image;
    void Awake()
    {
        image = GameObject.Find("LoadingBar").GetComponent<Image>();
    }
    void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }

}
