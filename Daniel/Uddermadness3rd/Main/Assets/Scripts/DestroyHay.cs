using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pepper")
        {
            Destroy(gameObject);
        }
    }
}
