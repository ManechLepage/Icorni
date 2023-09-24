using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Main Player Stats")]
    public float speed;
    public int health;
    public int maxHealth;

    [Space]
    [Header("Player Damage Stats")]
    public Weapon weapon;
    public List<ItemBuff> buffs = new List<ItemBuff>();

    [Space]
    [Header("Player Defense Stats")]
    public int defensePercentage;
    public List<ResistanceBuff> resistanceBonus = new List<ResistanceBuff>();

    [Space]
    [Header("Equipment Inventory")] 
    public InventoryObject equipmentInventory;
    public InventorySlot[] affectedSlots;
    public void Awake()
    {
        affectedSlots = new InventorySlot[equipmentInventory.container.items.Length];
    }

    public void CheckEquipment()
    {
        for (int i = 0; i < affectedSlots.Length; i++)
        {
            if (equipmentInventory.container.items[i].item != null)
            {
                if (affectedSlots[i].item == null)
                {
                    affectedSlots[i].item = equipmentInventory.container.items[i].item;
                }
                if (equipmentInventory.container.items[i].item.ID == affectedSlots[i].item.ID)
                {
                    affectedSlots[i].amount = equipmentInventory.container.items[i].amount;
                }
            }
        }
    }
}
