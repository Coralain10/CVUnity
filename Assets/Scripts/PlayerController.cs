using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed = 12;
    public float jumpForce = 5;
    private float forwardInput = 1;
    private bool isOnGround;
    private bool isGameOver;

    void Start()
    {
        isOnGround = true;
        isGameOver = false;
        playerRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        forwardInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * forwardInput);
        Jump();
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
}
