using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float force;
    public GameObject cannonball;
    public Transform barrel;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(cannonball, barrel);
            go.transform.localEulerAngles = Vector3.zero;
            go.GetComponent<Rigidbody>().AddForce(go.transform.up * force);
        }
    }
}
