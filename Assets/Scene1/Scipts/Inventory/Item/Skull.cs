using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Skull : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Skull(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedSkull = new Skull(info);
        clonnedSkull.state.amount = state.amount;
        return clonnedSkull;
    }
}
