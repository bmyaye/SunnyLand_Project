using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State { idle, running, jumping }
    private State state = State.idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        else
        {
            
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            state = State.jumping;
        }

        VelocityState();
        anim.SetInteger("state", + (int)state);
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }
        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

}
