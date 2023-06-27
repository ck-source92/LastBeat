using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AudioMainMenu : MonoBehaviour
{
    AudioSource m_AudioSource;
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        int numberScenePersist = FindObjectsOfType<AudioMainMenu>().Length;
        if (numberScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    void Update()
    {
        Debug.Log(Advertisement.isShowing + "hello");
        m_AudioSource.mute = Advertisement.isShowing;
    }
    public void ResetAudioMainMenu()
    {
        Destroy(gameObject);
    }
}
