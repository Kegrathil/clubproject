using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMoveOther : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;

    public float jumpForce;

    public Rigidbody2D rb;

    public bool grounded;

    public Transform groundChecker;

    public LayerMask mask;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundChecker.position, -transform.up, 0.1f, mask);
        grounded = hit.collider != null;
        if (grounded)
        {
            transform.parent = hit.transform;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);
    }
}
