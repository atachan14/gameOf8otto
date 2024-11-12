using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    BoxCollider2D boxCollider;

    public float moveSpeed = 20f;
    public float jumpSpeed = 0.8f;
    public float fallSpeed = 0.1f;

    bool rightMoving;
    bool leftMoving;
    Vector2 moveDirection;

    bool jumping;
    bool sitting;

    bool isGrounded = false;
    public LayerMask groundLayer; // ínñ ÇÃÉåÉCÉÑÅ[
    public int jumpingTimer = 0;
    public int maxJumpingTimer = 10;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) rightMoving = true;
        if (Input.GetKeyDown(KeyCode.A)) leftMoving = true;
        if (Input.GetKeyUp(KeyCode.D)) rightMoving = false;
        if (Input.GetKeyUp(KeyCode.A)) leftMoving = false;

        if (rightMoving) transform.position += Vector3.right * moveSpeed;
        if (leftMoving) transform.position += Vector3.left * moveSpeed;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) jumping = true;
        if (Input.GetKeyUp(KeyCode.W)) { jumping = false; jumpingTimer = 0; }

        if (jumping) jump();
        if (!isGrounded) transform.position += Vector3.down * fallSpeed;
    }

    void jump()
    {
        jumpingTimer++;
        transform.position += Vector3.up * jumpSpeed;
        if (jumpingTimer == maxJumpingTimer)
        {
            jumping = false;
            jumpingTimer = 0;
        }
    }

    public int getScore()
    {
        return score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            score--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }




}

