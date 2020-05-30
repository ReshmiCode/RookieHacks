using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    Vector2 leftBottom;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x - Time.deltaTime * speed;
        rigidbody2D.MovePosition(position);
    }

    private void LateUpdate()
    {
        if (rigidbody2D.position.x < leftBottom.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController player = other.GetComponent<CharacterController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
