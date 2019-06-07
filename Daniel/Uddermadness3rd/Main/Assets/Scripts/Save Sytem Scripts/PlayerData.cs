using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
//This is set as a Serializable system and it is not a MonoBehavior script
{

    public float[] position;
    // holds a group amount of text and/or numbers

    public PlayerData (Player player)
     // Gets data from player script
     {

        position= new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        // gets three positions x,y,z of the player and puts them in the group float

    }
}
