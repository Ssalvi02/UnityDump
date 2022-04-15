using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ini_speed;
    public float current_speed;
    public bool ball_fix = true;
    public bool first_cont = false;
    public float timer;
    public TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        current_speed = ini_speed;
    }

    void Update()
    {
        if (!ball_fix)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                UpdateVelocity();
                current_speed += 0.5f;
                timer = 3f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && ball_fix)
        {
            Launch();
            ball_fix = false;
        }

        if (rb.velocity.x < current_speed || rb.velocity.y < current_speed)
        {
            rb.velocity = rb.velocity.normalized * current_speed;
        }

    }


    private void Launch()
    {
        int x = (Random.Range(0, 2) * 2) - 1;
        float y = (Random.Range(0, 2) * 2) - 1;
        tr.emitting = true;
        rb.velocity = new Vector2(x* ini_speed, y* ini_speed).normalized * current_speed;
    }

    private void UpdateVelocity()
    {
        first_cont = true;
        if (rb.velocity.x > 0 && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + 0.5f, rb.velocity.y + 0.5f);
        }
        else if (rb.velocity.x < 0 && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - 0.5f, rb.velocity.y - 0.5f);
        }
        else if (rb.velocity.x < 0 && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - 0.5f, rb.velocity.y + 0.5f);
        }
        else if (rb.velocity.x > 0 && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + 0.5f, rb.velocity.y - 0.5f);
        }
    }
    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0f, 0f, 0f);
        tr.emitting = false;
        ball_fix = true;
        first_cont = false;
        current_speed = ini_speed;
    }

}
