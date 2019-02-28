using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCylinderControl : MonoBehaviour
{
    public float speed;
    public GameObject Cylinder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cylinder.transform.Rotate(0, speed, 0);

    }
}
