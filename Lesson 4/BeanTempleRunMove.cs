using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeanTempleRunMove : MonoBehaviour
{
    public float jump;
    public bool grounded;

    Rigidbody rb;

    public Vector3[] tracks;

    public int track = 0;

    public float switchSpeed;

    public Transform groundChecker;

    public LayerMask mask;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Physics.Raycast(groundChecker.position, -transform.up, 0.1f, mask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(0, jump, 0);
        }

        if (Input.GetKeyDown(KeyCode.A) && track > 0)
        {
            track--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && track < 2)
        {
            track++;
        }

        rb.transform.position = new Vector3(Mathf.Lerp(transform.position.x, tracks[track].x, switchSpeed * Time.deltaTime), transform.position.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("you lose!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
