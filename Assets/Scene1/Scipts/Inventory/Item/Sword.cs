using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Sword(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedSword = new Sword(info);
        clonnedSword.state.amount = state.amount;
        return clonnedSword;
    }
}
