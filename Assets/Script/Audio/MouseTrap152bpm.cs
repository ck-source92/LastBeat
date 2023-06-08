using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap152bpm : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioPlayer audioPlayer;
    private void Awake()
    {
        if (audioPlayer == null)
        {
            audioPlayer = FindObjectOfType<AudioPlayer>();
        }
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.clip = audioPlayer.mouseTrap152bpm;
            audioSource.Play();
        }
    }
}
