using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public int myVariable = 5;
    public float myFloat = 1.6f;
    public string myString;
    public char myChar;
    public bool myBool;

    public int[] myArray;
    public List<int> myList = new List<int>(4);

    public GameObject[] myObjects;

    private void Start()
    {
        myString = "whatever you wantfui hfoueyrgfouywg efoy3w";
        myChar = 'f';
        myBool = true;

        myArray = new int[3];

        myArray[1] = myVariable;
        myList[1] = myVariable;

        myList.Remove(myVariable);


        for(int i = 0; i < 5; i++)
        {
            DoSomething();
        }

        foreach(GameObject go in myObjects)
        {
            //go.SetActive(false);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 1, 0) * 1000);
        }
    }

    private void Update()
    {
        if(myFloat != 0.1f)
        {
            print(someCrazyNumber(myVariable));
        }

        foreach (GameObject go in myObjects)
        {
            //go.SetActive(false);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 1, 0) * myFloat);
        }
    }

    void DoSomething()
    {
        myVariable--;
    }

    float someCrazyNumber(int someInt)
    {
        someInt *= 5;
        float someFloat = someInt / 47.3f;
        someFloat /= Time.deltaTime;

        return someFloat;
    }
}
