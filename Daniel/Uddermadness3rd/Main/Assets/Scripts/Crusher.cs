using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    //setting two position
    public Transform pos1, pos2;
    //settting start position
    public Transform startPos;
    //float for the movment of the crusher
    public float speed;
    
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    //movment of the object
    void Update()
    {
        //if pos=pos1 next position the object will move to will be pos2
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        //if pos=pos2 next position the object will move to will be pos1
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        //moving the object according to next pos and speed 
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        //colour for gizmos
        Gizmos.color = new Color(1f, 1f, 1f, 0.5f);

        if (pos1 != null)
        {
            //draw cube on pos1
            Gizmos.DrawWireCube(pos1.position, Vector3.one * 0.25f);
        }

        if (pos2 != null)
        {
            //draw cube on pos2
            Gizmos.DrawWireCube(pos2.position, Vector3.one * 0.25f);
        }

        if (pos1 != null && pos2 != null)
        {
            //draw line between pos1 and pos2
            Gizmos.DrawLine(pos1.position, pos2.position);
        }
    }
}
