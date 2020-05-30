﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    private Vector2 leftBottom;
    private Vector2 rightTop;
    private SpriteRenderer spriteRenderer;
    private Vector2 spriteSize;
    private Vector2 spriteHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

      	leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightTop   = Camera.main.ViewportToWorldPoint(Vector3.one);
 
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize     = spriteRenderer.sprite.bounds.size;
        spriteHalfSize = spriteRenderer.sprite.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    private void LateUpdate()
    {
        // get the sprite's edge positions
        float spriteLeft   = transform.position.x - spriteHalfSize.x;
        float spriteRight  = transform.position.x + spriteHalfSize.x;
        float spriteBottom = transform.position.y - spriteHalfSize.y;
        float spriteTop    = transform.position.y + spriteHalfSize.y;
 
        // initialize the new position to the current position
        Vector3 clampedPosition = transform.position;
 
        // if any of the edges surpass the camera's bounds,
        // set the position TO the camera bounds (accounting for sprite's size)
        if(spriteLeft < leftBottom.x)
        {
            clampedPosition.x = leftBottom.x + spriteHalfSize.x;
        }
        else if(spriteRight > rightTop.x)
        {
            clampedPosition.x = rightTop.x - spriteHalfSize.x;
        }
 
        if(spriteTop < leftBottom.y)
        {
            clampedPosition.y = leftBottom.y + spriteHalfSize.y;
        }
        else if(spriteTop > rightTop.y)
        {
            clampedPosition.y = rightTop.y - spriteHalfSize.y;
        }
 
        transform.position = clampedPosition;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
