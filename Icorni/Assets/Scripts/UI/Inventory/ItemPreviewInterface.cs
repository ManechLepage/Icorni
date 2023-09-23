using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPreviewInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;
    public Player player;
    [Space]
    [Header("Preview UI")]
    public Image spritePreview;
    public TextMeshProUGUI namePreview;
    public TextMeshProUGUI descriptionPreview;

    public void UpdateItemPreview()
    {
        ItemObject item = inventory.database.GetItem[player.mouseItem.lastClickedItem.item.ID];

        spritePreview.sprite = item.uiDisplay;
        spritePreview.color = new Color(1, 1, 1, 1);

        namePreview.text = item.itemName;
        descriptionPreview.text = item.description;
    }

    public void ClearItemPreview()
    {
        spritePreview.sprite = null;
        spritePreview.color = new Color(1, 1, 1, 0);

        namePreview.text = "";
        descriptionPreview.text = "";
    }
}
