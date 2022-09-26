using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingIntro : MonoBehaviour
{
    string myName = "Brian";
    int myAge = 19;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //myAge++;
        //Debug.Log("Hi, my name and age is " + myName + " " + myAge);

        Debug.Log(Input.GetAxis("Horizontal") + "-" + Input.GetAxis("Vertical"));
    }
}
