using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    public Collider[] wallCollider;

    public void SetWallsActive(bool active)
    {
        foreach (Collider c in wallCollider)
        {
            c.enabled = active;
        }
    }
}
