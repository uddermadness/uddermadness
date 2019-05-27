using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TabItem
{
    public Image buttonGraphic, iconGraphic;

    public Text buttonText;

    public GameObject view;
} 

[ExecuteInEditMode]
public class TabControl : MonoBehaviour
{
    public TabItem[] items;

    public Color primaryColor, secondaryColor;

    private void OnEnable()
    {
        SwitchTabIndex(0);
    }

    public void SwitchTabIndex(int index)
    {
        ClearAllButtons();
        items[index].buttonGraphic.color = secondaryColor;
        items[index].iconGraphic.color = primaryColor;
        items[index].buttonText.color = primaryColor;
        items[index].view.SetActive(true);
    }

    private void ClearAllButtons()
    {
        foreach (TabItem item in items)
        {
            item.buttonGraphic.color = primaryColor;
            item.iconGraphic.color = secondaryColor;
            item.buttonText.color = secondaryColor;
            item.view.SetActive(false);
        }
    }
}
