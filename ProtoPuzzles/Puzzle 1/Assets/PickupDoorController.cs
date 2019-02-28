using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDoorController : MonoBehaviour
{
    public GameObject Door;
    public Transform closedPos, openPos;
    public bool doorOpens;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = doorOpens ? openPos.position : closedPos.position;
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, pos, 5f * Time.deltaTime);
    }

    public void Open(bool isOpen)
    {
        doorOpens = isOpen;
    }
}
