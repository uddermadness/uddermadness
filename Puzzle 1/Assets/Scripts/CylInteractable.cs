using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylInteractable : MonoBehaviour
{
    public CylinderController cylinderController;

    public void Activate()
    {
        if(cylinderController != null)
        {
            cylinderController.SetOpen(true);
        }
    }

    public void Deactivate()
    {
        if (cylinderController != null)
        {
            cylinderController.SetOpen(false);
        }
    }
}
