using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
//This is set as static so that it can only be read, this not a MonoBehavior script
{
    public static void SavePlayer (Player player)
    //Set as static so that it cannot be edited by other scripts
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // variable to encrypt and read the data 
        string path = Application.persistentDataPath + "/player.data";
        // variable to set a path (location) of the save file
        FileStream stream = new FileStream(path, FileMode.Create);
        // variable to open a stream (to send and gat data) and use the stream to connect to the path and create the file with the data

        PlayerData data = new PlayerData(player);
        // variable of what is the data that is going to be sent

        formatter.Serialize(stream, data);
        // send and encrypt the data
        stream.Close();
        // close the stream/connection
    }

    public static PlayerData LoadPlayer ()
    // Set as static so that it cannot be edited by other scripts
    // PlayerData refers to the script

    {
        string path = Application.persistentDataPath + "/player.data";
        // variable that refers to the location that it needs the data from
        if (File.Exists(path))
        // if the data need from the set location is found
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // variable to encrypt and read the data 
            FileStream stream = new FileStream(path, FileMode.Open);
            // variable to open a stream (to send and gat data) and use the stream to connect to the path and open the file that holds the data

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            // variable that reads the encrypted data for the Player data Script
            stream.Close();
            // close the stream/connection
            Debug.Log("Load " + data);

            return data;
            // get the Data and stop
        }
        else
        // if the data need from the set location is not found
        {
            Debug.LogError("Save file not found in " + path);
            // Show and error than say where is the file and that was not found at the set location 
            return null;
            // stop 
        }
    }
}
