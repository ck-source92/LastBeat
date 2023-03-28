using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    int percentage;
    private int percentageLevel1;
    private int percentageLevel2;
    private int percentageLevel3;

    PlayerController _playerController;
    GameSession _gameSession;
    AudioPlayer audioPlayer;

    [SerializeField] int diamondReward = 2;

    public static bool isFinish = false;
    void Awake()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameSession = FindObjectOfType<GameSession>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Update()
    {
        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Level1:
                CustomPreference(percentageLevel1, "higest_percentage_level1", percentage);
                CheckHigestPercentage(percentageLevel1, "higest_percentage_level1");
                GetReachPlayer();
                break;
            case Loader.Scene.Level2:
                CustomPreference(percentageLevel2, "higest_percentage_level2", percentage);
                CheckHigestPercentage(percentageLevel2, "higest_percentage_level2");
                GetReachPlayer();
                break;
            case Loader.Scene.Level3:
                CustomPreference(percentageLevel3, "higest_percentage_level3", percentage);
                CheckHigestPercentage(percentageLevel3, "higest_percentage_level3");
                GetReachPlayer();
                break;
        }
    }

    private void CustomPreference(int result, string key, int value)
    {
        _ = PlayerPrefs.GetInt(key, 0);
        PlayerPrefs.SetInt(key, value);
    }
    private void GetReachPlayer()
    {
        if (_playerController == null)
            _playerController = FindObjectOfType<PlayerController>();
        else
        {
            float referenceValue = gameObject.transform.position.x;
            float distanceValue = _playerController.transform.position.x;

            float result = (distanceValue / referenceValue) * 100f;
            percentage = Mathf.RoundToInt(result);
            if (percentage <= 100)
                _gameSession.TextLevelResult.text = percentage + " %";
            else
                percentage = 100;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioPlayer.PlayLevelCompleteClip();
            StartCoroutine(FinishGame());
        }
    }
    IEnumerator FinishGame()
    {
        yield return new WaitForSecondsRealtime(.5f);
        if (_gameSession != null)
        {
            _gameSession.PanelGameOver.SetActive(true);
            _gameSession.TextLevelResult.text = percentage + " %";
            _gameSession.SetDiamond(diamondReward);
        }
        isFinish = true;
        Time.timeScale = 0f;
    }

    private void CheckHigestPercentage(int percentage, string key)
    {
        if (percentage > PlayerPrefs.GetInt(key, 0))
        {
            PlayerPrefs.SetInt(key, percentage);
        }
    }
}
