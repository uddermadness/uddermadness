using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Activate();
        }
    }
      

    public void Activate()
    {
        if (doorController != null)
        {
            doorController.SetOpen(true);
        }
    }
}
