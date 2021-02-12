using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
