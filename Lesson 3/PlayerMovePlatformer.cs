using UnityEngine;

public class PlayerMovePlatformer : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public bool grounded;

    public Transform groundChecker;

    public Rigidbody2D rb;

    public LayerMask mask;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundChecker.position, -transform.up, 0.1f, mask);

        grounded = hit.collider != null;

        if (grounded)
        {
            transform.parent = hit.transform;
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}
