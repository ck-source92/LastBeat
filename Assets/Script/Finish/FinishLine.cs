using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    int percentage;
    private int percentageTutorialScene;
    private int percentageLevel1 = 0;
    private int percentageLevel2 = 0;
    private int percentageLevel3 = 0;

    PlayerController _playerController;
    GameSession _gameSession;
    AudioPlayer audioPlayer;

    [SerializeField] int diamondReward = 2;

    public static bool isFinish = false;
    public bool isFinishTutorial = false;
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
            case Loader.Scene.Tutorial:
                _gameSession.TextLevels.text = "Tutorial";
                CheckHigestPercentage(percentageTutorialScene, "higest_percentage_tutorial_scene");
                GetReachPlayer();
                break;
            case Loader.Scene.Level1:
                _gameSession.TextLevels.text = "Level 1";
                percentageLevel1 = percentage;
                CheckHigestPercentage(percentageLevel1, "higest_percentage_level1");
                GetReachPlayer();
                break;
            case Loader.Scene.Level2:
                _gameSession.TextLevels.text = "Level 2";
                percentageLevel2 = percentage;
                CheckHigestPercentage(percentageLevel2, "higest_percentage_level2");
                GetReachPlayer();
                break;
            case Loader.Scene.Level3Middle:
                _gameSession.TextLevels.text = "Level 3";
                percentageLevel3 = percentage;
                CheckHigestPercentage(percentageLevel3, "higest_percentage_level3");
                GetReachPlayer();
                break;
            case Loader.Scene.Level3_Unbeat:
                _gameSession.TextLevels.text = "Level 3";
                percentageLevel3 = percentage;
                CheckHigestPercentage(percentageLevel3, "higest_percentage_level3");
                GetReachPlayer();
                break;
            case Loader.Scene.Level3_Upbeat:
                _gameSession.TextLevels.text = "Level 3";
                percentageLevel3 = percentage;
                CheckHigestPercentage(percentageLevel3, "higest_percentage_level3");
                GetReachPlayer();
                break;
        }
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
        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Tutorial:
                isFinishTutorial = true;
                int isTutorialFinishInt = isFinishTutorial ? 1 : 0;
                PlayerPrefs.SetInt("isFinishTutorial", isTutorialFinishInt);
                break;
            default:
                break;
        }
        if (_gameSession != null)
        {
            _gameSession.PanelGameOver.SetActive(true);
            _gameSession.TextLevelResult.text = percentage + " %";
            _gameSession.SetDiamond(diamondReward);
        }
        isFinish = true;
        Time.timeScale = 0f;
    }

    private void CheckHigestPercentage(int percentage_level, string key)
    {
        if (percentage_level > PlayerPrefs.GetInt(key))
        {
            PlayerPrefs.SetInt(key, percentage_level);
        }
    }
}
