using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelingController : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioPlayer audioPlayer;

    [SerializeField] Button ButtonLevel3;
    [SerializeField] Button ButtonLock;

    [SerializeField] TextMeshProUGUI textUnlockFail;

    private AudioMainMenu _audioMainMenu;

    int coinPlayer;

    private bool levelWasUnlock = false;
    int isLevelWasUnlockInt;

    private void Awake()
    {
        if(_audioMainMenu == null)
        {
            _audioMainMenu = FindObjectOfType<AudioMainMenu>();
        }

        if (audioPlayer == null)
            audioPlayer = FindObjectOfType<AudioPlayer>();
        if (audioSource == null)
            audioSource = FindObjectOfType<AudioSource>();

    }
    private void Start()
    {
        coinPlayer = PlayerPrefs.GetInt("total_coins");
        isLevelWasUnlockInt = PlayerPrefs.GetInt("levelWasUnlock");

        if (PlayerPrefs.GetInt("levelWasUnlock") == 1)
        {
            ButtonLevel3.interactable = true;
            ButtonLock.gameObject.SetActive(false);
        }

    }
    public void BackToMenu()
    {
        Loader.Load(Loader.Scene.Home);
    }
    public void UnlockLevelThree()
    {
        if (coinPlayer >= 119 && isLevelWasUnlockInt == 0)
        {
            var newCoin = coinPlayer - 119;
            PlayerPrefs.SetInt("total_coins", newCoin);

            ButtonLevel3.interactable = true;
            ButtonLock.gameObject.SetActive(false);
            GameObject.Find("DialogGroup").SetActive(false);

            levelWasUnlock = true;
            int isLevelWasUnlock = levelWasUnlock ? 1 : 0;
            PlayerPrefs.SetInt("levelWasUnlock", isLevelWasUnlock);
        }
        else
        {
            ButtonLock.gameObject.SetActive(true);
            textUnlockFail.gameObject.SetActive(true);
        }
    }
    public void LoadLevelOne()
    {
        Loader.Load(Loader.Scene.Level1);
        Loader.SceneSelected = Loader.Scene.Level1;
        FindObjectOfType<AudioMainMenu>().ResetAudioMainMenu();
    }
    public void LoadLevelTwo()
    {
        Loader.Load(Loader.Scene.Level2);
        Loader.SceneSelected = Loader.Scene.Level2;
        FindObjectOfType<AudioMainMenu>().ResetAudioMainMenu();
    }
    public void LoadLevelThree()
    {
        float valueDeffuzifikasi = PlayerPrefs.GetFloat("result_deffuzifikasi");
        // unbeat
        if (valueDeffuzifikasi <= 6.0)
        {
            Loader.Load(Loader.Scene.Level3_Unbeat);
            Loader.SceneSelected = Loader.Scene.Level3_Unbeat;
            _audioMainMenu.ResetAudioMainMenu();
        }
        // upbeat
        else if (valueDeffuzifikasi > 6.0 && valueDeffuzifikasi <= 14.0)
        {
            Loader.Load(Loader.Scene.Level3Middle);
            Loader.SceneSelected = Loader.Scene.Level3Middle;
            _audioMainMenu.ResetAudioMainMenu();
        }
        else if (valueDeffuzifikasi > 14.0)
        {
            Loader.Load(Loader.Scene.Level3_Upbeat);
            Loader.SceneSelected = Loader.Scene.Level3_Upbeat;
            _audioMainMenu.ResetAudioMainMenu();
        }
       
    }
}
