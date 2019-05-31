using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    public float axisX;
    public float axisY;
    public float axisZ;
    //public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(axisX * Time.deltaTime,axisY * Time.deltaTime,axisZ * Time.deltaTime);
    }
}
