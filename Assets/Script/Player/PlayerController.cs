using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Speeds.Speed currentSpeed;
    [SerializeField] GameModes.Gamemodes CurrentGameMode;

    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    Animator animator;

    readonly float[] SpeedValue =
    {
        8.6f,    // 1
        10.4f,   // 2
        12.96f,  // 3
        15.6f,   // 4
        19.29f   // 5
    };

    [Header("Ground Check")]
    [SerializeField] float GroundCheckRadius;
    [SerializeField] LayerMask GroundMask;

    [SerializeField] Sprite[] listSprite;
    [SerializeField] public Transform SpriteRotate;

    public int Gravity = 1;
    float speed;
    public bool clickProcess = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    void Start()
    {
        Time.timeScale = 1f;

        speed = PlayerPrefs.GetFloat("result_deffuzifikasi");

        switch (Loader.SceneSelected)
        {
            case Loader.Scene.Level3Middle:
                transform.position += speed * Time.deltaTime * Vector3.right;
                break;
        }
    }
    void FixedUpdate()
    {
        transform.position += SpeedValue[(int)currentSpeed] * Time.deltaTime * Vector3.right;
        spriteRenderer.sprite = listSprite[(int)CurrentGameMode];
        Invoke(CurrentGameMode.ToString(), 0);
    }
    public bool OnGround()
    {
        return Physics2D.OverlapBox(transform.position + Vector3.down * Gravity * 0.5f, Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }
    #region Type Characters
    private void Cube()
    {
        animator.enabled = false;
        Generic.CreateGameMode(rb, this, true, 20.5269f, 9.057f, true, false, 409.1f);
    }

    private void Ship()
    {
        animator.enabled = false;
        rb.gravityScale = 2.93f * (Input.GetMouseButton(0) ? -1 : 1) * Gravity;
        Generic.LimitYVelocity(19.29f, rb);
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
        SpriteRotate.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    private void Gatot()
    {
        animator.enabled = true;
        Generic.CreateGameMode(rb, this, true, 238.29f, 6.2f, false, true, 0, 238.29f);
    }
    #endregion
    public void ChangeBehaviourPlayerThroughPortal(GameModes.Gamemodes Gamemodes, Speeds.Speed Speed, int gravity, int State)
    {
        switch (State)
        {
            case 0:
                currentSpeed = Speed;
                break;
            case 1:
                CurrentGameMode = Gamemodes;
                break;
            case 2:
                Gravity = gravity;
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * gravity;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("JumpyJump"))
        {
            Vector3 jumpDirection = transform.up + transform.forward;

            rb.velocity = Vector2.zero;
            rb.AddForce(jumpDirection.normalized * 27.89175f * Gravity, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounching"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 jumpDirection = transform.up + transform.forward;

                rb.velocity = Vector2.zero;
                rb.AddForce(jumpDirection.normalized * 27.89175f * Gravity, ForceMode2D.Impulse);
            }
        }
    }
}
