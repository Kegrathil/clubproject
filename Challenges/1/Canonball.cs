using UnityEngine;

public class Canonball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Score!");
    }
}
