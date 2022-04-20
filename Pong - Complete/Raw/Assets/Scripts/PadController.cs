using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour
{
    public int player_id;
    public float speed = 5f;
    public bool bot;
    public Rigidbody2D rb;
    public float vert_move;
    public float vert_move2;
    public GameObject ball;
    public BallController bc;
    public Rigidbody2D rb_ball;
    public float limit = 3.5f;


    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");
        bc = ball.GetComponent<BallController>();
        rb_ball = ball.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ResetPad();

        if (player_id == 1)
        {
            rb.velocity = new Vector2(0f, speed * vert_move);
            transform.position = new Vector3(7.5f, Mathf.Clamp(transform.position.y, -limit, limit), 0f);
        }

        if (player_id == 2 && !bot)
        {
            rb.velocity = new Vector2(0f, speed * vert_move2);
            transform.position = new Vector3(-7.5f, Mathf.Clamp(transform.position.y, -limit, limit), 0f);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            bot = false;
        }

        if (bot)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(Mathf.Lerp(transform.position.y, ball.transform.position.y, 0.03f), -limit, limit), 0f);
        }

    }

    private void FixedUpdate()
    {
        vert_move = Input.GetAxis("Vertical1");
        vert_move2 = Input.GetAxis("Vertical2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            if ((vert_move > 0 || vert_move2 > 0) && rb_ball.velocity.y < 0)
            {
                Vector2 new_dir = new Vector2(rb_ball.velocity.x, -rb_ball.velocity.y);
                rb_ball.velocity = new_dir;
            }

            if ((vert_move < 0 || vert_move2 < 0) && rb_ball.velocity.y > 0)
            {
                Vector2 new_dir = new Vector2(rb_ball.velocity.x, -rb_ball.velocity.y);
                rb_ball.velocity = new_dir;
            }
            if (transform.localScale.y > 1.7)
            {
                transform.localScale -= new Vector3(0f, 0.1f, 0f);
                limit += 0.05f;
            }
            speed += 0.2f;
        }
    }

    public void ResetPad()
    {
        if (ball.transform.position.x < -9f || ball.transform.position.x > 9f)
        {
            transform.localScale = new Vector3(0.6f, 3f, 0f);
            speed = 8f;
            limit = 3.5f;
        }
    }
}
