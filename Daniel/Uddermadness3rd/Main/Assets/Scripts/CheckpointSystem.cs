using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public GameObject Player;
    public Vector3 checkpointPosition;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.transform.position = checkpointPosition;
        }
    }
        void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkpointPosition = Player.transform.position;
            player.SavePlayer();
            Debug.Log(checkpointPosition);
        }   
    }
}
