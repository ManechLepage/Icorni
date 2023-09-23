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
    public Sprite uiDisplay;
    public ItemType type;
    
    [Header("Item")]
    public ItemRarity ItemRarity;
    public bool isStackable;

    [Space]
    [Header("Buffs & Resistance")]
    public List<ItemBuff> buffs = new List<ItemBuff>();
    public List<Resistance> resistances = new List<Resistance>();


    
    [Space]
    [Header("Description")]
    [TextArea(15, 20)]
    public string description;
}

[System.Serializable]
public class ItemBuff
{
    public Attribute attribute;
    public int value;
}

[System.Serializable]
public class Resistance
{
    public DamageType damageType;
    public int value;
}