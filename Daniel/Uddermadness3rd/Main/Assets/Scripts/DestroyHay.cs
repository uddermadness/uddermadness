using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if hay is hit by object with a tag of pepper, hay gameobject will be destroyed
        if (other.tag == "Pepper")
        {
            Destroy(gameObject);
        }
    }
}
