using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // this script goes in the player components

    //this could be added to the manager
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        //Save the data taken/needed from this object
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        // get and load the data in the the savesystem

        // health = data.health;
        // get the health data taken from the loaded data.

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        // get the position data taken from the loaded data.

    }

}
