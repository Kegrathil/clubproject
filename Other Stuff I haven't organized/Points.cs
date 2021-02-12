using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int points;

    private void Update()
    {
        GetComponent<Text>().text = points.ToString();
    }
}
