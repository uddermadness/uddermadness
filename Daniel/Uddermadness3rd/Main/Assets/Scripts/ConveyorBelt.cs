using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    //setting endpoint where the object will be moved to
    public Transform endPoint;
    //setting the gameobject
    public GameObject belt;
    //setting a float for the spead the object will move with
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //on trigger the object will be moved towards the endpoint
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
    }
}
