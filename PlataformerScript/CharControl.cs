using System.Collections;
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

    [Header("Dash")]
    [SerializeField] private float dash_vel;
    [SerializeField] private float dash_time;
    [SerializeField] private Vector2 dash_dir;
    [SerializeField] private bool is_dashing;
    [SerializeField] private bool dash_unlocked = false;
    [SerializeField] private bool can_dash = true;
    public TrailRenderer tr;


    public bool is_jumping;
    public bool is_grounded;
    public bool can_control;

    public  char last_area; //h = hub, j = jungle, s = sky, p = swamp, l = lava, c = cyber;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        tr = GetComponentInChildren<TrailRenderer>();
        can_control = true;
    }
    // Update is called once per frame
    void Update()
    {

        //Controla o dash
        if (dash_unlocked)
        {
            bool dash_input = Input.GetButtonDown("Dash");

            if (dash_input && can_dash)
            {
                tr.emitting = true;
                is_dashing = true;
                can_dash = false;
                can_control = false;
                dash_dir = new Vector2(horiz_move, vert_move);

                if (dash_dir == Vector2.zero)
                {
                    dash_dir = Vector2.up;
                }
                StartCoroutine(StopDash());
            }

            if (is_dashing)
            {
                rb.velocity = dash_dir.normalized * dash_vel;
                return;
            }
        }

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
            can_dash = true;
            can_control = true;
            cj_time_count = cj_time;
        }
        else
        {
            cj_time_count -= Time.deltaTime;
        }

        //Controla o buffer do pulo
        if (Input.GetButtonDown("Jump"))
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

        if(Input.GetButton("Jump") && is_jumping)
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


        if (Input.GetButtonUp("Jump"))
        {
            is_jumping = false;
            cj_time_count = 0f;
        }

    }

    void FixedUpdate()
    {
        if (can_control)
        {
            horiz_move = Input.GetAxisRaw("Horizontal");
            vert_move = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horiz_move * speed, rb.velocity.y);
        }
        anim.SetBool("Run", horiz_move != 0f);
        anim.SetBool("Grounded", is_grounded);

    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dash_time);
        can_control = true;
        tr.emitting = false;
        is_dashing = false;
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
