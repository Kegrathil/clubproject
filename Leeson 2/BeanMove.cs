using UnityEngine;

public class BeanMove : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public CharacterController cc;
    public float gravity;
    public float jumpForce;

    public Collider winningCol;

    private void Update()
    {
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");

        cc.Move(moveDirection * speed * Time.deltaTime);

        if (!cc.isGrounded)
        {
            moveDirection.y -= Time.deltaTime * gravity;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == winningCol)
        {
            print("YOU WIN");
        }
    }
}
