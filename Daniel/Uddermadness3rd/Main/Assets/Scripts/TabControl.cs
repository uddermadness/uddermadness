using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* [System.Serializable]
public class TabItem
{
    public Image buttonGraphic, iconGraphic;

    public Text buttonText;

    public GameObject view;
} 
 */

public class TabControl : MonoBehaviour
{
    /* public TabItem[] items;

    public buttonImage primaryImage, secondaryImage;

    private void OnEnable()
    {
        SwitchTabIndex(0);
    }

    public void SwitchTabIndex(int index)
    {
        ClearAllButtons();
        items[index].buttonGraphic.image = secondaryImage;
        items[index].iconGraphic.image = primaryImage;
        items[index].buttonText.image = primaryImage;
        items[index].view.SetActive(true);
    }

    private void ClearAllButtons()
    {
        foreach (TabItem item in items)
        {
            item.buttonGraphic.image = primaryImage;
            item.iconGraphic.image = secondaryImage;
            item.buttonText.image = secondaryImage;
            item.view.SetActive(false);
        }
    } */

    SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void change (Sprite differentSprite)
    {
        spriteRenderer.sprite = differentSprite;
    }
}
