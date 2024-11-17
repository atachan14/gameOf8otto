using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public float maxJumpingTimer;


    private bool rightMoving;
    private bool leftMoving;
    private bool jumping;

    private bool isGrounded = false;
    private float jumpingTimer = 0;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D)) rightMoving = true;
        if (Input.GetKeyDown(KeyCode.A)) leftMoving = true;
        if (Input.GetKeyUp(KeyCode.D)) rightMoving = false;
        if (Input.GetKeyUp(KeyCode.A)) leftMoving = false;

        if (rightMoving) transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (leftMoving) transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) jumping = true;
        if (Input.GetKeyUp(KeyCode.W)) { jumping = false; jumpingTimer = 0; }

        if (jumping) Jump();
    }

    void Jump()
    {
        jumpingTimer++;
        transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
        if (jumpingTimer > maxJumpingTimer / Time.deltaTime)
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("Scores"))
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


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Augment>().Exe();
        Debug.Log("PlayerScript onTriggerEntert");
    }
}

