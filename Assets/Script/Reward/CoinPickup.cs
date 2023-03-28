using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointForCoinPickups = 1;

    GameSession gameSession;
    AudioPlayer audioPlayer;
    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioPlayer.PlayCoinPickupClip();
            gameSession.AddCoin(pointForCoinPickups);
            Destroy(gameObject);
        }
    }
}
