..using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public BoxCollider2D bc;
    public LayerMask GroundLayer;
    public SpriteRenderer sr;
    public Animator anim;
    public Rigidbody2D rb;

    public float speed;
    public float jump_force;
    public float jump_time;
    private float jump_time_count;
    public float cj_time;
    private float cj_time_count;
    public float bj_time;
    private float bj_time_count;
    private float horiz_move;
    private float vert_move;

    public bool is_jumping;
    public bool is_grounded;
    public bool can_control;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        can_control = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Check se ta no chao
        is_grounded = Physics2D.OverlapBox(bc.bounds.center, bc.bounds.size, 0f, GroundLayer);

        //Flipa sprite
        Flip();


        //Limitar velocidade de queda
        if (rb.velocity.y < -10f)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -10f, jump_force));
        }

        //Coyote time (Pulo fora do chao)
        if (is_grounded)
        {
            is_dashing = false;
            can_dash = true;
            can_control = true;
            cj_time_count = cj_time;
        }
        else
        {
            cj_time_count -= Time.deltaTime;
        }

        //Controla o buffer do pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bj_time_count = bj_time;
        }
        else
        {
            bj_time_count -= Time.deltaTime;
        }

        //Controle de pulo
        if (bj_time_count > 0f && cj_time_count > 0f)
        {
            is_jumping = true;
            jump_time_count = jump_time;
            Jump();
            bj_time_count = 0f; 
        }

        if(Input.GetKey(KeyCode.Space) && is_jumping)
        {
            if(jump_time_count > 0)
            {
                Jump();
                jump_time_count -= Time.deltaTime;
            }
            else
            {
                is_jumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            is_jumping = false;
            cj_time_count = 0f;
        }

    }

    void FixedUpdate()
    {
        if (can_control)
        {
            horiz_move = Input.GetAxis("Horizontal");
            vert_move = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(horiz_move * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        anim.SetBool("Run", horiz_move != 0f);
        anim.SetBool("Grounded", is_grounded);

    }


        private void Flip()
    {
        if (horiz_move > 0.01f)
        {
            sr.flipX = false;
        }
        else if (horiz_move < -0.01f)
        {
            sr.flipX = true;
        }
    }

    private void Jump()
    {
        if (can_control)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }
    }

}
