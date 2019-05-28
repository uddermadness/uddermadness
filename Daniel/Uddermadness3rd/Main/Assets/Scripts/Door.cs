using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Inventory inventory;

    public ItemData requires;

    public void Open()
    {
        if (inventory.Has(requires))
        {
            Debug.Log("Opening");
        }
    }
}
