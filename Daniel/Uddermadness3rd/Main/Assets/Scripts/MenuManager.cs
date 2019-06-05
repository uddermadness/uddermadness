using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Transform Player;
    
    public GameObject Phone, Map, Inventory, Option;

    public Button MapButt, InventoryButt, OptionButt;
    // Start is called before the first frame update
    void Start()
    {
        Phone.SetActive(false);
        Map.SetActive(false);
        Inventory.SetActive(false);
        Option.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Phone.activeInHierarchy)
            {
                PauseGame();
                MapButton();
            }
            else if (Phone.activeInHierarchy)
            {
                ResumeGame();
            }
        }

        if (!Map.activeInHierarchy)
        {MapButt.interactable = true;}
        else if (Map.activeInHierarchy)
        {MapButt.interactable = false;}

        if (!Inventory.activeInHierarchy)
        {InventoryButt.interactable = true;} 
        else if (Inventory.activeInHierarchy)
        {InventoryButt.interactable = false;}

        if (!Option.activeInHierarchy)
        {OptionButt.interactable = true;}
        else if (Option.activeInHierarchy)
        {OptionButt.interactable = false;}
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Phone.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        Phone.SetActive(false);
    }

    public void MapButton()
    {
        Map.SetActive(true);
        Inventory.SetActive(false);
        Option.SetActive(false);
    }

    public void InvtButton()
    {
        Inventory.SetActive(true);
        Option.SetActive(false);
        Map.SetActive(false);
    }

    public void OptButton()
    {
        Option.SetActive(true);
        Inventory.SetActive(false);
        Map.SetActive(false);
    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
