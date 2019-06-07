using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerTrigger : MonoBehaviour
{
    public Vector3 checkpointPosition;
    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            gameObject.transform.position = checkpointPosition;
        }
        if (other.tag == "Done")
        {
             SceneManager.LoadScene(0);
        }
        if(other.tag == "Checkpoint")
        {
            checkpointPosition = gameObject.transform.position;
            player.SavePlayer();
            Debug.Log(checkpointPosition);
        }
    }
}
