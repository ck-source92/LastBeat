using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private int coin;
    private int diamond;

    float timer;

    List<int> listAttempNumber = new List<int>();
    //[1, 2, 3]

    int _attemp = 1;
    [SerializeField] TextMeshProUGUI TextAttemps;
    [SerializeField] TextMeshProUGUI TextPickupCoin;
    [SerializeField] TextMeshProUGUI TextTimer;

    [Header("Panel Game")]
    [SerializeField] public GameObject PanelGameOver;

    [Header("Panel Game Over")]
    [SerializeField] TextMeshProUGUI TextLevels;
    [SerializeField] public TextMeshProUGUI TextLevelResult;
    [SerializeField] TextMeshProUGUI TextLevelComplete;

    void Awake()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    void Start()
    {
        RandomNumber();
        TextAttemps.text = "Attemp " + _attemp.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        DisplayTime(timer);
    }

    private void RandomNumber()
    {
        for (int i = 1; i < 54; i++)
        {
            int randomNumber = Random.Range(1, 120);
            Debug.Log($"random number : {randomNumber}");
            listAttempNumber.Add(randomNumber);
        }
    }
    public void ProcessPlayerDeath()
    {
        _attemp++;
        TextAttemps.text = "Attemp " + _attemp.ToString();
        // save attempt 
        PlayerPrefs.SetInt("attempt", _attemp);
        if (listAttempNumber.Contains(_attemp))
        {
            PanelGameOver.SetActive(true);
            TextLevelComplete.enabled = false;
        }
        else
        {
            Invoke("TakeLife", .5f);
        }
    }

    void TakeLife()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TextTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void SetDiamond(int diamondToAdd)
    {
        diamond += diamondToAdd;
        if (_attemp < 5)
        {
            diamond += 10;
        }
        GetTotalDiamonds();
    }

    public void AddCoin(int coinsToAdd)
    {
        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Level1:
                coin += coinsToAdd;
                var coinLevel1 = PlayerPrefs.GetInt("coin_level_1", 0);
                PlayerPrefs.SetInt("coin_level_1", coin + coinLevel1);
                break;


            case Loader.Scene.Level2:
                coin += coinsToAdd;
                var coinLevel2 = PlayerPrefs.GetInt("coin_level_2", 0);
                PlayerPrefs.SetInt("coin_level_2", coin + coinLevel2);
                break;
            case Loader.Scene.Level3:
                coin += coinsToAdd;
                var coinLevel3 = PlayerPrefs.GetInt("coin_level_3", 0);
                PlayerPrefs.SetInt("coin_level_3", coin + coinLevel3);
                break;

        }
        TextPickupCoin.text = coin.ToString();
        GetTotalCoins();
    }

    public void GetTotalCoins()
    {
        var totalCoins = PlayerPrefs.GetInt("total_coins", 0);
        PlayerPrefs.SetInt("total_coins", totalCoins + coin);
    }

    public void GetTotalDiamonds()
    {
        var totalDiamonds = PlayerPrefs.GetInt("total_diamonds", 0);
        PlayerPrefs.SetInt("total_diamonds", totalDiamonds + diamond);
    }
    public void ResetGameSession()
    {
        Destroy(gameObject);
    }

    public void ReplayGame()
    {
        if (FinishLine.isFinish)
        {
            ResetGameSession();
        }
        PanelGameOver.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void BackHome()
    {
        SceneManager.LoadScene("Home");
        Destroy(gameObject);
    }

}
