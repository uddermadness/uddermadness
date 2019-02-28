using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDoorInteraction : MonoBehaviour
{
    public GameObject Pickup;
    public PickupDoorController pickupController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" & Pickup == null ) {
            
           Activate();
            
        }


    }
    public void Activate()
    {
        if (pickupController != null)
        {
            pickupController.Open(true);
        }
    }

}
