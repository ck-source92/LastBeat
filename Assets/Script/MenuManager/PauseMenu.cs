using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _GameIsPaused = false;

    [Header("Panel Pause")]
    [SerializeField] private GameObject PanelPause;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    private void Update()
    {
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
    }
    public void PauseGame()
    {
        audioSource.Pause();
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
        _GameIsPaused = true;
    }

    public void ResumeGame()
    {
        audioSource.Play();
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
        _GameIsPaused = false;
    }
    public void BackHome()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
        FindObjectOfType<ScreenPersist>().ResetScenePersist();
        Loader.Load(Loader.Scene.MenuLevels);
    }

}
