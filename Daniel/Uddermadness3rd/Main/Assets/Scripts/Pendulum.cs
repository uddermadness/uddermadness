using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    //start rotation and end rotation
    Quaternion start, end;
    //angle at which the pendulum will start swinging
    [SerializeField, Range(0.0f, 360.0f)] private float angle = 90.0f;
    //speed pendulum will rotate with
    [SerializeField, Range(0.0f, 5.0f)] private float speed = 2.0f;
    //start time (can be offsetted so the pendulum will start at lower position)
    [SerializeField, Range(0.0f, 10.0f)] private float startTime = 0.0f;
    //setting float for swing limit
    private float swingLimit = 180f;
    

    // Start is called before the first frame update
        void Start()
    {
        //on start the start roation will be of angle
        //the end will be of -angle
        start = PendulumRotation(angle);
        end = PendulumRotation(-angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //setting start time to according to framerate
        startTime += Time.deltaTime;
        //rotation between start and end
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }


    Quaternion PendulumRotation(float angle)
    {
        //variable pendulum rotation will be the roataion set before
        var pendulumRotation = transform.rotation;
        //setting variable angle z to pendulum roation and rotation set before
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > swingLimit)
            angleZ -= 360;
        else if (angleZ < swingLimit)
            angleZ += 360;
        
        //pendulum roation will rotate according to the vectors of the object. 
        //in case of vector z, will rotate according to angle which was set before  
        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }
}
