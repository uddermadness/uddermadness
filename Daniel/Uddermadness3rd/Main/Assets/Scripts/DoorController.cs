using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //setting gameobject door
    public GameObject Door;
    //transforms for position of when door is open and closed
    public Transform closedPos, openPos;
    //boolean if door is open or not
    public bool doorIsOpen;

    // Update is called once per frame
    void Update()
    {
        // if condition - pos will take openPos if door is open, otherwise closedPos will be used.
        // ? - if, : - else
        Vector3 pos = doorIsOpen ? openPos.position : closedPos.position;
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, pos, 5f * Time.deltaTime);
    }
    // setting boolean to isopen
    public void SetOpen(bool isOpen)
    {
        doorIsOpen = isOpen;
    }
}
