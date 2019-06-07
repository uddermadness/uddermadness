using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerTrigger : MonoBehaviour
{

    public CheckpointSystem checkpoint;
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
            gameObject.transform.position = checkpoint.checkpointPosition;
        }
        if (other.tag == "Done")
        {
             SceneManager.LoadScene(0);
        }
    }
}
