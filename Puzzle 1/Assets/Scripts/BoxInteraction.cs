using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trig")
        {
            InteractableObject intObj = other.GetComponent<InteractableObject>();
            if (intObj != null)
            {
                intObj.Activate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trig")
        {
            InteractableObject intObj = other.GetComponent<InteractableObject>();
            if (intObj != null)
            {
                intObj.Deactivate();
            }
        }
    }

}
