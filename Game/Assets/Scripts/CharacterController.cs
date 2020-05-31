using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;
    int score;

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;
    Animator animator;
    enum Bin { blue, green, gray };
    Bin binMode = Bin.blue;
    float horizontal;
    float vertical;

    private Vector2 leftBottom;
    private Vector2 rightTop;
    private SpriteRenderer spriteRenderer;
    private Vector2 spriteSize;
    private Vector2 spriteHalfSize;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightTop = Camera.main.ViewportToWorldPoint(Vector3.one);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.sprite.bounds.size;
        spriteHalfSize = spriteRenderer.sprite.bounds.extents;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.Play("BlueBin");
            binMode = Bin.blue;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.Play("GrayBin");
            binMode = Bin.gray;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.Play("GreenBin");
            binMode = Bin.green;
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    private void LateUpdate()
    {
        float spriteLeft = transform.position.x - spriteHalfSize.x;
        float spriteRight = transform.position.x + spriteHalfSize.x;
        float spriteBottom = transform.position.y - spriteHalfSize.y;
        float spriteTop = transform.position.y + spriteHalfSize.y;

        Vector3 clampedPosition = transform.position;


        if (spriteLeft < leftBottom.x)
        {
            clampedPosition.x = leftBottom.x + spriteHalfSize.x;
        }
        else if (spriteRight > rightTop.x)
        {
            clampedPosition.x = rightTop.x - spriteHalfSize.x;
        }

        if (spriteTop < leftBottom.y)
        {
            clampedPosition.y = leftBottom.y + spriteHalfSize.y;
        }
        else if (spriteTop > rightTop.y)
        {
            clampedPosition.y = rightTop.y - spriteHalfSize.y;
        }

        transform.position = clampedPosition;
    }

    public void ChangeScore(string name)
    {
        if (name.Equals("paper(Clone)"))
        {
            if (binMode == Bin.blue)
            {
                ChangeScore(10);
            }
            else
            {
                ChangeScore(-5);
                ChangeHealth(-1);
            }
        }
        if (name.Equals("plastic(Clone)"))
        {
            if (binMode == Bin.green)
            {
                ChangeScore(10);
            }
            else
            {
                ChangeScore(-5);
                ChangeHealth(-1);
            }
        }
        if (name.Equals("glass(Clone)"))
        {
            if (binMode == Bin.gray)
            {
                ChangeScore(10);
            }
            else
            {
                ChangeScore(-5);
                ChangeHealth(-1);
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            startBlinking = true;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        if (currentHealth <= 0)
        {
            Debug.Log(score);
            FinalScoreController.instance.SetValue(score);
            Application.LoadLevel(3);
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        ScoreController.instance.SetValue(score);
    }

    float spriteBlinkingTimer = 0.0f;
    float spriteBlinkingMiniDuration = 0.1f;
    float spriteBlinkingTotalTimer = 0.0f;
    float spriteBlinkingTotalDuration = 2.0f;
    bool startBlinking = false;

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            sprite.enabled = true;
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (sprite.enabled == true)
            {
                sprite.enabled = false;
            }
            else
            {
                sprite.enabled = true;
            }
        }
    }
}
