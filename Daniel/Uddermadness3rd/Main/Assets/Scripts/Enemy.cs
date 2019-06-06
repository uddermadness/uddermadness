using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent pathfinder;
    Transform target;

    public float detectDist;
    public float stoppingDist;
    public float retreatDist;
    public float speed;

    public bool stun = false;

    public float stunTimer;
    public float stunDur;
    public GameObject drop;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent> ();
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    
        //StartCoroutine (UpdatePath ());
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector3.Distance(transform.position, target.position);
        //Debug.Log("I am at" + transform.position);

        if (distFromPlayer < detectDist && !stun) // || health < behavior.health
        {
            pathfinder.SetDestination (target.position); 

            if (distFromPlayer > stoppingDist)
            {
                //Debug.Log("Found Target");
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                //Vector3 targetPosition = new Vector3(target.position.x,0,target.position.z);
                //yield return new WaitForSeconds(refreshRate);
            }
            else if (distFromPlayer < retreatDist)
            {
                //Debug.Log("Slowing down");
                transform.position = Vector3.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);   
            }
        }


        // if (Input.GetKeyDown("space"))
        // {
        //     stun = true;
        //     stunTimer = stunDur;
        // }

        if( stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        else
        {
            stun = false;
        }

        if (Input.GetKeyDown("k"))
        {
            Destroy(gameObject);
            Instantiate(drop, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ice")
        {
            Debug.Log("Freeze motherfucker");
            stun = true;
            stunTimer = stunDur;
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
        // if no behavior on script, stop here.
        // if (behavior == null) return;

        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.down, stoppingDist);
        
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.down, retreatDist);

        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.down, detectDist);
    }
#endif
}
