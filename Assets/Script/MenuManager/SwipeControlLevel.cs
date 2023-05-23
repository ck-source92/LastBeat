using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SwipeControlLevel : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioPlayer audioPlayer;

    [SerializeField] GameObject horizontalScrollbar;
    [SerializeField] Button ButtonLevel3;
    [SerializeField] Button ButtonLock;

    [SerializeField] TextMeshProUGUI textUnlockFail;

    private AudioMainMenu _audioMainMenu;

    float scroll_pos = 0;
    int coinPlayer;
    float[] pos;
    int position = 0;

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

    void Update()
    {
        coinPlayer = PlayerPrefs.GetInt("total_coins");
        isLevelWasUnlockInt = PlayerPrefs.GetInt("levelWasUnlock");

        if (PlayerPrefs.GetInt("levelWasUnlock") == 1)
        {
            ButtonLevel3.interactable = true;
            ButtonLock.gameObject.SetActive(false);
        }

        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = horizontalScrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    horizontalScrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(horizontalScrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                }
            }
        }

    }
    public void Previous()
    {
        if (position > 0)
        {
            position -= 1;
            scroll_pos = pos[position];
        }
    }
    public void Next()
    {
        if (position < pos.Length - 1)
        {
            position += 1;
            scroll_pos = pos[position];
        }
    }

    public void BackToMenu()
    {
        Loader.Load(Loader.Scene.Home);
    }

    public void UnlockLevelThree()
    {
        if (coinPlayer >= 219 && isLevelWasUnlockInt == 0)
        {
            var newCoin = coinPlayer - 219;
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
