using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// needed to show some outlines on the editor scene only
using UnityEngine.AI;
// need for the enemy to make it move on the designated area with nav mash.

public class Enemy : MonoBehaviour
{

    NavMeshAgent pathfinder; // this was used to get information from the navmash.
    Transform target; // to get the position of the target.

    public float detectDist;
    public float stoppingDist;
    public float retreatDist;
    // this three where used as detect distance from the target.
    public float speed; // to set the speed of the enemy.

    public bool stun = false; // an effect that could affect the enemy done by using a boolion.

    public float stunTimer; // a timer that would count down the amount of time for the stun to stop.
    public float stunDur; // to set the stun duration.
    public GameObject drop; // this would be an item that the enemy would drop when dying.

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent> ();
        // to connect the variable pathfinder and refer to the nevmash used on the areas designated for the enemy to move.
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        // to connect and refer the variable to the position of the target, the player.

        //StartCoroutine (UpdatePath ());
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector3.Distance(transform.position, target.position);
        // a variable that measures the distance from the target.
        //Debug.Log("I am at" + transform.position);

        if (distFromPlayer < detectDist && !stun) // || health < behavior.health
        // if the distance from the player smaller than the detect distance and the boolien stun is false.
        {
            pathfinder.SetDestination (target.position);
            // use the the NevMash to create a path to get to target

            if (distFromPlayer > stoppingDist)
            // if the distance from the player is greater than the distance from the set distance in the stoppingDist
            {
                //Debug.Log("Found Target");
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                // than move to the position of the target at the set speed by the time for every second

                //Vector3 targetPosition = new Vector3(target.position.x,0,target.position.z);
                //yield return new WaitForSeconds(refreshRate);
            }
            else if (distFromPlayer < retreatDist)
            // if the distance from the player is smaller then the distance set by the retreatDist.
            {
                //Debug.Log("Slowing down");
                transform.position = Vector3.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
                // than move away from the target at the set speed by the time for every second.
            }
        }


        // if (Input.GetKeyDown("space"))
        // if the user presse the “SpaceBar”

        // {
        //     stun = true;
               // the bullion stun is active
        //     stunTimer = stunDur;
               // the stunTimer is set the same as the stunDur
        // }

        if ( stunTimer > 0)
        // if the stunTimer is greater than zero
        {
            stunTimer -= Time.deltaTime;
            // keep counting down the timer
        }
        else
        // if it is not
        {
            stun = false;
            // set the boolien to false
        }

        if (Input.GetKeyDown("k"))
        // if the user presse the key “K”
        {
            Destroy(gameObject);
            // destroy the object (Enemy)
            Instantiate(drop, transform.position, transform.rotation);
            // create the item set in the variable drop at the same position  and rotation of the enemy 
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ice")
        // if an object with tag tuches this object
        {
            Debug.Log("Freeze motherfucker");
            stun = true;
            // the bullion stun is active
            stunTimer = stunDur;
            // the stunTimer is set the same as the stunDur

        }
    }

    // IEnumerator UpdatePath() {
    //     float refreshRate = 0.5f;

    //     while (target != null)
    //     {
    //         Vector3 targetPosition = new Vector3(target.position.x,0,target.position.z);
    //         pathfinder.SetDestination (target.position);
    //         yield return new WaitForSeconds(refreshRate);
    //     }
    // }



    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {

        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.down, stoppingDist);
        
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.down, retreatDist);

        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.down, detectDist);
    }
#endif
}
