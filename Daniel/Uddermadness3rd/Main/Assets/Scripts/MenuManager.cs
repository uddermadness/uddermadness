using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// used to be able to affect the UI

public class MenuManager : MonoBehaviour
{
    public Transform Player;
    // get the location of the object
    
    public GameObject Phone, Map, Inventory, Option;
    // variables of four objects
    public Button MapButt, InventoryButt, OptionButt;
    // variables of three buttons
    void Start()
    {
        Phone.SetActive(false);
        Map.SetActive(false);
        Inventory.SetActive(false);
        Option.SetActive(false);
        // Set all the object as de-active (do not show in the scene)
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        // if the ESC button is pressed
        {
            if (!Phone.activeInHierarchy)
            {
                PauseGame();
                MapButton();
                // activate the PhoneGame and MapButton functions
            }
            else if (Phone.activeInHierarchy)
            // if the object called phone is active            
            {
                ResumeGame();
                // activate the ResumeGame function
            }
        }

        if (!Map.activeInHierarchy)
        // If the map object is not active
        { MapButt.interactable = true;}
        // Make the MapButt interactable
        else if (Map.activeInHierarchy)
        // but if the map object is active
        { MapButt.interactable = false;}
        // disable the MapButt from being interactable

        if (!Inventory.activeInHierarchy)
        // If the Inventory object is not active
        { InventoryButt.interactable = true;}
        // Make the OptionButt interactable
        else if (Inventory.activeInHierarchy)
        // but if the Option object is active
        {InventoryButt.interactable = false;}
        // disable the InventoryButt from being interactable

        if (!Option.activeInHierarchy)
        // If the Option object is not active
        { OptionButt.interactable = true;}
        // Make the OptionButt interactable
        else if (Option.activeInHierarchy)
        // but if the Option object is active
        { OptionButt.interactable = false;}
        // disable the MapButt from being interactable
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        // stop the time in the game
        Phone.SetActive(true);
        // active the Phone Object on the scene
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        // set time in the game to normal (1 second for every 1 Second)
        Phone.SetActive(false);
        // de-active the Phone Object on the scene
    }

    public void MapButton()
    {
        Map.SetActive(true);
        // activate the Map object in the scene
        Inventory.SetActive(false);
        Option.SetActive(false);
        // deactivate the Map and Option objects in the scene
    }

    public void InvtButton()
    {
        Inventory.SetActive(true);
        // activate the Inventory object in the scene
        Option.SetActive(false);
        Map.SetActive(false);
        // deactivate the Map and Option objects in the scene
    }

    public void OptButton()
    {
        Option.SetActive(true);
        // activate the Option object in the scene
        Inventory.SetActive(false);
        Map.SetActive(false);
        // deactivate the Map and Inventory objects in the scene
    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
        // Quit Exit the Game
    }

}
