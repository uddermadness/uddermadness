using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylBoxInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trig" )
        {
            CylInteractable intObj = other.GetComponent<CylInteractable>();
            if(intObj != null)
            {
                intObj.Activate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trig")
        {
            CylInteractable intObj = other.GetComponent<CylInteractable>();
            if (intObj != null)
            {
                intObj.Deactivate();
            }
        }
    }
}
