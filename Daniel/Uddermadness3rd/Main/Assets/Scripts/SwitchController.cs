using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerEnter(Collider other)
    {
        //if switch is jit by bullet with a tag of milk the boolean is set to true
        if (other.tag == "Milk")
        {
            Activate();
        }
    }
      

    public void Activate()
    {
        //setting boolean to true
        if (doorController != null)
        {
            doorController.SetOpen(true);
        }
    }
}
