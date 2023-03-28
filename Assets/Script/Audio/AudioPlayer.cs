using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Level Complete")]
    [SerializeField] AudioClip levelCompleteClip;
    [SerializeField] [Range(0f, 5f)] float levelCompleteVolume = 2f;

    [Header("Explotion")]
    [SerializeField] AudioClip explotionClip;
    [SerializeField] [Range(0f, 5f)] float explotionVolume = 4f;

    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickupClip;
    [SerializeField] [Range(0f, 5f)] float coinPickupVolume = 2f;

    public void PlayLevelCompleteClip()
    {
        if (levelCompleteClip != null)
        {
            PlayClip(levelCompleteClip, levelCompleteVolume);
        }
    }
    public void PlayCoinPickupClip()
    {
        if (coinPickupClip != null)
        {
            PlayClip(coinPickupClip, coinPickupVolume);
        }
    }

    public void PlayExplotionClip()
    {
        if (explotionClip != null)
        {
            PlayClip(explotionClip, explotionVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
