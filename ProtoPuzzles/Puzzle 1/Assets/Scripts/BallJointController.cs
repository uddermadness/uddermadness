﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJointController : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Toppler")
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * 800f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Toppler")
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.left * 400f);
        }
    }
}
