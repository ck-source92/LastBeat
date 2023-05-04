using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Speeds.Speed currentSpeed;
    [SerializeField] GameModes.Gamemodes CurrentGameMode;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    readonly float[] SpeedValue =
    {
        8.6f,    // 1
        10.4f,   // 2
        12.96f,  // 3
        15.6f,   // 4
        19.29f   // 5
    };

    float gravityScaleAtStart;
    //int percentage;

    [Header("Ground Check")]
    [SerializeField] Transform GroundCheckTransform;
    [SerializeField] float GroundCheckRadius;
    [SerializeField] LayerMask GroundMask;

    [SerializeField] Sprite[] listSprite;
    [SerializeField] Transform SpriteRotate;

    [HideInInspector]
    [SerializeField] float jumpHeight = 26.6581f;
    int Gravity = 1;
    bool isUpsideDown;

    Vector3 lastVelocity;

    bool isDie = false;

    private int jumpCount = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }
    void Start()
    {
        Time.timeScale = 1f;
        gravityScaleAtStart = rb.gravityScale;
    }
    void Update()
    {
        if (isDie)
        {
            return;
        }
        transform.position += SpeedValue[(int)currentSpeed] * Time.deltaTime * Vector3.right;
        spriteRenderer.sprite = listSprite[(int)CurrentGameMode];

        Debug.Log($"jump count : {jumpCount}");
        PlayerPrefs.SetInt("jump_count", jumpCount);

        if (rb.velocity.y < -24.4f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -24.4f);
        }

        lastVelocity = rb.velocity;
        Invoke(CurrentGameMode.ToString(), 0);
    }

    bool OnGround()
    {
        return Physics2D.OverlapBox(GroundCheckTransform.position + Vector3.up - Vector3.up * (Gravity - 1 / -2), Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }

    #region Type Characters
    private void Cube()
    {
        animator.enabled = false;
        if (OnGround())
        {
            Vector3 Rotation = SpriteRotate.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            SpriteRotate.transform.rotation = Quaternion.Euler(Rotation);

            if (Input.GetMouseButton(0))
            {
                jumpCount++;
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpHeight * Gravity, ForceMode2D.Impulse);
            }
        }
        else
        {
            SpriteRotate.Rotate(Vector3.back, 452.4152186f * Time.deltaTime * Gravity);
        }

        rb.gravityScale = gravityScaleAtStart * Gravity;
    }

    private void Ship()
    {
        animator.enabled = false;

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
        SpriteRotate.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetMouseButton(0))
        {
            rb.gravityScale = -4.314969f;
            jumpCount++;
        }
        else
        {
            rb.gravityScale = 4.314969f;
        }

        rb.gravityScale *= Gravity;
    }

    private void Gatot()
    {
        animator.enabled = true;

        SpriteRotate.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            jumpCount++;
            if (isUpsideDown)
            {
                rb.gravityScale = Mathf.Abs(Mathf.Round(gravityScaleAtStart * 28.9129812f) * Gravity);
                spriteRenderer.flipY = false;
            }
            else
            {
                rb.gravityScale = Mathf.Round(gravityScaleAtStart * 28.9129812f) * -Gravity;
                spriteRenderer.flipY = true;
            }

            isUpsideDown = !isUpsideDown;
        }

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
            rb.AddForce(jumpDirection.normalized * 38.89175f * Gravity, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) { }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounching"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 jumpDirection = transform.up + transform.forward;

                rb.velocity = Vector2.zero;
                rb.AddForce(jumpDirection.normalized * 38.89175f * Gravity, ForceMode2D.Impulse);
            }
        }
    }
}
