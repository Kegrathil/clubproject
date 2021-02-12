using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject playerPrefab;

    private void Start()
    {
        transform.position = startPos;

        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.player = transform;
        }
        foreach (Student enemy in FindObjectsOfType<Student>())
        {
            enemy.player = transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "spikes" && col.transform.parent.parent.GetChild(0).gameObject.activeSelf)
        {
            col.transform.parent.parent.GetChild(0).gameObject.SetActive(false);
            col.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
            Die();
        }
        if(col.gameObject.tag == "croc")
        {
            //coroutine for setkinematic
            Die();
        }
    }

    public void Die()
    {

        FindObjectOfType<Points>().points++;
        Instantiate(playerPrefab, startPos, Quaternion.identity);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<Animator>().speed = 0;
        GetComponent<DepressedMove>().enabled = false;

        if (FindObjectOfType<Points>().points == 3)
        {
            FindObjectOfType<Canvas>().transform.GetChild(3).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        this.enabled = false;
    }
}
