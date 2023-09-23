using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Artifact
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum Attribute
{
    Speed,
    Health,
    Defense
}

public enum DamageType
{
    Melee,
    Range,
    Fire,
    Poison
}

public abstract class ItemObject : ScriptableObject
{
    [Header("Item Stats")]
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    public string itemName;
    
    [Header("Buffs & Resistances")]
    public ItemBuff[] buffs;
    public ResistanceBuff[] resistance;
    public bool isStackable;
    
    [Space]
    [Header("Description")]
    [TextArea(15, 20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
    public Item()
    {
        Name = "";
        ID = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
    }
}


[System.Serializable]
public class ItemBuff
{
    public Attribute attribute;
    public int value;
}

[System.Serializable]
public class ResistanceBuff
{
    public DamageType damageType;
    public int value;
}