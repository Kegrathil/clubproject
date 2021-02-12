using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressedMove : MonoBehaviour
{
    public float speed;
    public float jump;

    public bool grounded;

    public Rigidbody2D rb;
    public Transform groundchecker;
    public LayerMask mask;

    public Animator anim;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundchecker.position, 0.1f, mask);

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if(rb.velocity.x != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if(rb.velocity.x > 0)
        {
            transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }
        if (rb.velocity.x < 0)
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
        }
    }
}
