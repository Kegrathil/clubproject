using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public float speed;
    public float range;

    private Rigidbody2D rb;

    public Transform player;

    public Transform spike;

    public float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            rb.AddForce((spike.position - transform.position).normalized * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "spikes" && col.transform.parent.parent.GetChild(0).gameObject.activeSelf)
        {
            col.transform.parent.parent.GetChild(0).gameObject.SetActive(false);
            col.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(Die());
        }
        if (col.gameObject.tag == "croc")
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }
}
