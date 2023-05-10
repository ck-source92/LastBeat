using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] float GroundCheckRadius;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] ParticleSystem ExplotionEffect;

    BoxCollider2D boxCollider2D;
    GameSession _GameSession;
    AudioPlayer audioPlayer;

    AudioSource audioSource;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        _GameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Die();
    }
    bool IsTouchingWall()
    {
        return Physics2D.OverlapBox((Vector2)transform.position + (Vector2.right * 0.555f), Vector2.up * 0.8f + (Vector2.right * GroundCheckRadius), 0, GroundMask);
    }
    private void Die()
    {
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Hazards")) || IsTouchingWall())
        {
            Instantiate(ExplotionEffect.gameObject, transform.position, Quaternion.identity);
            audioPlayer.PlayExplotionClip();
            audioSource.Stop();
            _GameSession.ProcessPlayerDeath();
            Destroy(gameObject);
        }

    }
}
