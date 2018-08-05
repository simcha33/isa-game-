using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndReached : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Application.Quit(); 
        }
    }
}