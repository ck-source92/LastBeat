using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI LEVEL SELECTOR")]
    [SerializeField] private Slider SliderLevel1;
    [SerializeField] private Slider SliderLevel2;
    [SerializeField] private Slider SliderLevel3;

    [SerializeField] private TextMeshProUGUI ProgressLevel1;
    [SerializeField] private TextMeshProUGUI ProgressLevel2;

    [SerializeField] private TextMeshProUGUI coinLevel1;
    [SerializeField] private TextMeshProUGUI coinLevel2;
    [SerializeField] private TextMeshProUGUI coinLevel3;

    [SerializeField] private TextMeshProUGUI totalCoin;
    [SerializeField] private TextMeshProUGUI totalDiamond;
    private void Awake()
    {
        SliderLevel1 = GameObject.Find("SliderLevel1").GetComponent<Slider>();
        SliderLevel2 = GameObject.Find("SliderLevel2").GetComponent<Slider>();
        SliderLevel3 = GameObject.Find("SliderLevel3").GetComponent<Slider>();
        ProgressLevel1 = GameObject.Find("TextProgress1").GetComponent<TextMeshProUGUI>();
        ProgressLevel2 = GameObject.Find("TextProgress2").GetComponent<TextMeshProUGUI>();
        coinLevel1 = GameObject.Find("CoinLevel1").GetComponent<TextMeshProUGUI>();
        coinLevel2 = GameObject.Find("CoinLevel2").GetComponent<TextMeshProUGUI>();
        coinLevel3 = GameObject.Find("CoinLevel3").GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("total_coins", 999);
    }
    
    private void Start()
    {
        totalCoin.text = $"{PlayerPrefs.GetInt("total_coins")}";
        totalDiamond.text = $"{PlayerPrefs.GetInt("total_diamonds")}";

        coinLevel1.text = $"Coin : {PlayerPrefs.GetInt("coin_level_1")}";
        coinLevel2.text = $"Coin : {PlayerPrefs.GetInt("coin_level_2")}";
        coinLevel3.text = $"Coin : {PlayerPrefs.GetInt("coin_level_3")}";
    }
    private void Update()
    {
        SliderLevel1.value = PlayerPrefs.GetInt("higest_percentage_level1");
        SliderLevel2.value = PlayerPrefs.GetInt("higest_percentage_level2");
        SliderLevel3.value = PlayerPrefs.GetInt("higest_percentage_level3");

        ProgressLevel1.text = $"{PlayerPrefs.GetInt("higest_percentage_level1")} %";
        ProgressLevel2.text = $"{PlayerPrefs.GetInt("higest_percentage_level2")} %";
    }
}

