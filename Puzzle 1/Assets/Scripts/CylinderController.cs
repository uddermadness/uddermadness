using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float speed;
    public GameObject Cylinder;
    public Transform closedPos, openPos;
    

    public bool cylIsOpen;
    // Update is called once per frame
    void Update()
    {
        Cylinder.transform.Rotate(0, speed, 0);

        Vector3 pos = cylIsOpen ? openPos.position : closedPos.position;
        Cylinder.transform.position = Vector3.MoveTowards(Cylinder.transform.position, pos, 5f * Time.deltaTime);

    }

    public void SetOpen(bool isOpen)
    {
        cylIsOpen = isOpen;
    }
}
