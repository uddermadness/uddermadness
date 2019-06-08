using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    //setting a flot speed for speed rotataion
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //on update the gameobject will rotate z-axis occrding to the speed 
        gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
