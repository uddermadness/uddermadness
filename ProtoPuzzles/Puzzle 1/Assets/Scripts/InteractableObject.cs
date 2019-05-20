using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public DoorController doorController;

    public void Activate()
    {
        if (doorController != null)
        {
            doorController.SetOpen(true);
        }
    }

    public void Deactivate()
    {
        if (doorController != null)
        {
            doorController.SetOpen(false);
        }
    }
}
