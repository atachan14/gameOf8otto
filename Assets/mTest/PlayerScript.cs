using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    BoxCollider2D boxCollider;

    float moveSpeed = 0.5f;
    float jumpSpeed = 0.5f;

    bool rightMoving;
    bool leftMoving;
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

        //boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) rightMoving = true;
        if (Input.GetKeyDown(KeyCode.A)) leftMoving = true;
        if (Input.GetKeyDown(KeyCode.W) && isGrounded) jumping = true;
        if (Input.GetKeyDown(KeyCode.S)) sitting = true;

        if (Input.GetKeyUp(KeyCode.D)) rightMoving = false;
        if (Input.GetKeyUp(KeyCode.A)) leftMoving = false;
        if (Input.GetKeyUp(KeyCode.W)) { jumping = false; jumpingTimer = 0; }
        if (Input.GetKeyUp(KeyCode.S)) sitting = false;

        if (rightMoving) transform.position += Vector3.right * moveSpeed;
        if (leftMoving) transform.position += Vector3.left * moveSpeed;
        if (jumping) jump();
        if (sitting) sit();
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

    void sit()
    {

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
        // 地面から離れた場合
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false; // 地面から離れたら
        }
    }

    public int getLife()
    {
        return life;
    }

}

