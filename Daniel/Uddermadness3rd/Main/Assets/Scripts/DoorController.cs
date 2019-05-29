using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public Transform closedPos, openPos;

    public bool doorIsOpen;

    // Update is called once per frame
    void Update()
    {
        // if condition - pos will take openPos if door is open, otherwise closedPos will be used.
        // ? - if, : - else
        Vector3 pos = doorIsOpen ? openPos.position : closedPos.position;
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, pos, 5f * Time.deltaTime);
    }

    public void SetOpen(bool isOpen)
    {
        doorIsOpen = isOpen;
    }
}
