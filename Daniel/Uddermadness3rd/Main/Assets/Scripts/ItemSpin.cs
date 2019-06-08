using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    //give value to variables according to which axis you went to rotate on
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
        // spinning game objects selected axis as a scripted animation
        gameObject.transform.Rotate(axisX * Time.deltaTime,axisY * Time.deltaTime,axisZ * Time.deltaTime);
    }
}
