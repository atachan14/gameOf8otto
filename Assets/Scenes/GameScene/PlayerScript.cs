using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MoveInTimePerson
{
    public Rigidbody2D rb;

    public float moveSpeed = 20f;
    public float jumpSpeed = 0.8f;
    public float fallSpeed = 0.1f;

    bool rightMoving;
    bool leftMoving;

    bool jumping;

    bool isGrounded = false;
    public LayerMask groundLayer; // ínñ ÇÃÉåÉCÉÑÅ[
    public int jumpingTimer = 0;
    public int maxJumpingTimer = 10;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (jumping) Jump();
        if (!isGrounded) transform.position += Vector3.down * fallSpeed;
    }

    void Jump()
    {
        jumpingTimer++;
        transform.position += Vector3.up * jumpSpeed;
        if (jumpingTimer == maxJumpingTimer)
        {
            jumping = false;
            jumpingTimer = 0;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int num)
    {
        this.score += num;
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

        if(collision.gameObject.layer == LayerMask.NameToLayer("Scores"))
        {
            AddScore(collision.gameObject.GetComponent<ScoresPerant>().getScore());
            collision.gameObject.GetComponent<ScoresPerant>().destroyExe();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AddScore(-collision.gameObject.GetComponent<EnemySC>().GetAtk());
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Augment"))
        {
            collision.gameObject.GetComponent<Augment>().Exe();
            Debug.Log("PlayerScript LayerMask.Augment hit");

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

