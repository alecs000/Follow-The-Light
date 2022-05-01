using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItemState : IInventoryItemState
{
    public int itemAmount;
    public bool IsItemEqipped;
    public int amount { get=> itemAmount; set => itemAmount=value; }
    public bool isEquipped { get=> IsItemEqipped; set=> IsItemEqipped=value; }
    public InventoryItemState()
    {
        itemAmount = 0;
        IsItemEqipped = false;
    }
}
