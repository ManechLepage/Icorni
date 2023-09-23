using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryPrefab;
    [Space]
    [Header("Inventory Placement")]
    public Vector2 INV_START;
    public Vector2 MARGIN_BETWEEN_ITEMS;
    public int NBR_OF_COLS;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            DisplaySlot(i);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i]))
            {
                itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            }
            else
            {
                DisplaySlot(i);
            }
        }
    }

    public void DisplaySlot(int i)
    {
        GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
        obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.container[i].item.uiDisplay;
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
        itemsDisplayed.Add(inventory.container[i], obj);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(INV_START.x + (MARGIN_BETWEEN_ITEMS.x * (i % NBR_OF_COLS)), INV_START.y + (-MARGIN_BETWEEN_ITEMS.y * (i / NBR_OF_COLS)), 0f);
    }
}
