using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float Speed;
    public float jumpHeight;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();



    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y == 1)
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }

        }
    }

    void PlayerMovement(){
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3 (hor, 0f, ver)* Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectWall"))
        {
            WallHandler handler = other.gameObject.GetComponent<WallHandler>();
            handler.SetWallsActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ObjectWall"))
        {
            WallHandler handler = other.gameObject.GetComponent<WallHandler>();
            handler.SetWallsActive(true);
        }
    }
}
