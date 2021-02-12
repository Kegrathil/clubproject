using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private void Start()
    {
        foreach(Rigidbody rb in transform.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
            GetComponent<Transform>();
            print(transform.position);
            gameObject.SetActive(false);
        }
    }
}
