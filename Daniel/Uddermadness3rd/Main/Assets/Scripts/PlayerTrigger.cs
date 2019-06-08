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
    // checing collisions for the player
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Obstacle")
        {
            //changing the player position to the last checkpoint position on death
            gameObject.transform.position = checkpointPosition;
        }
        if (other.tag == "Done")
        {
            //at the end of the level reloads the scene
             SceneManager.LoadScene(0);
        }
        if(other.tag == "Checkpoint")
        {
            //when a checkpoint is triggered the position of the last checkpoint is saved
            //and auto save feature is triggered
            checkpointPosition = gameObject.transform.position;
            player.SavePlayer();
            Debug.Log(checkpointPosition);
        }
    }
}
