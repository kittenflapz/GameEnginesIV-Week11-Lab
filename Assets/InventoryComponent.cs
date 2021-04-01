﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ItemScriptables> Items = new List<ItemScriptables>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public enum ItemCategory
{
    None,
    Weapon,
    Equipment,
    Consumable,
    Ammo
}