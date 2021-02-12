using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float vision;
    public float range;

    [HideInInspector] public  Transform player;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.position) <= vision)
        {
            rb.AddForce((player.position - transform.position).normalized * speed);
            if (Vector3.Distance(transform.position, player.position) <= range)
            {
                StartCoroutine(EndGame());
            }
        }
    }

    public IEnumerator EndGame()
    {
        FindObjectOfType<Canvas>().transform.GetChild(2).gameObject.SetActive(true);
        player.GetComponent<DepressedMove>().enabled = false;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(0);
    }
}
