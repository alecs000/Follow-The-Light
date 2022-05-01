using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papper : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();

    public Papper(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedPapper = new Papper(info);
        clonnedPapper.state.amount = state.amount;
        return clonnedPapper;
    }
}
