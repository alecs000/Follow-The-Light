using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crutch : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Crutch(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedCrutch = new Crutch(info);
        clonnedCrutch.state.amount = state.amount;
        return clonnedCrutch;
    }
}
