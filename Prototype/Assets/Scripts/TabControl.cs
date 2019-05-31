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

    public Sprite OnClick; // Drag your first sprite here
    public Sprite NotClicked; // Drag your second sprite here

    private SpriteRenderer spriteRenderer; 


    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        spriteRenderer.sprite = OnClick; // set the sprite to sprite1
    }
    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetMouseButtonDown(0))
        {
            ChangeSprite();
        }
    }

    void ChangeSprite() {
        if (spriteRenderer.sprite == OnClick && spriteRenderer == null) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = NotClicked;
        }
         else
        {
            spriteRenderer.sprite = OnClick; // otherwise change it back to sprite1
        }
    }
}
