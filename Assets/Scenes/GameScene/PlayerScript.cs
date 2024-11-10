using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    BoxCollider2D boxCollider;

    float moveSpeed =20f;
    public float jumpSpeed = 0.8f;

    bool rightMoving;
    bool leftMoving;
    Vector2 moveDirection;

    bool jumping;
    bool sitting;

    public bool isGrounded = false;
    public LayerMask groundLayer; // 地面のレイヤー
    int jumpingTimer = 0;
    int maxJumpingTimer = 10;

    int life = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) rightMoving = true;
        if (Input.GetKeyDown(KeyCode.A)) leftMoving = true;
        if (Input.GetKeyUp(KeyCode.D)) rightMoving = false;
        if (Input.GetKeyUp(KeyCode.A)) leftMoving = false;

        // 移動方向の決定
        if (rightMoving) moveDirection = Vector2.right;  // 右移動
        else if (leftMoving) moveDirection = Vector2.left; // 左移動
        else moveDirection = Vector2.zero;  // 何も押していなければ停止

      

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) jumping = true;
        if (Input.GetKeyUp(KeyCode.W)) { jumping = false; jumpingTimer = 0; }

        if (jumping) jump();
    }

    void FixedUpdate()
    {
        Debug.Log("Move Direction: " + moveDirection);
        Debug.Log("Velocity before: " + rb.velocity);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);  // Y軸の速度は変更しない
        Debug.Log("Velocity after: " + rb.velocity);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            life--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false; 
        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 10, 200, 20), "Debug Value: " + life);
    }



}

