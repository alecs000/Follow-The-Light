using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Knife : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Knife(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedKnife = new Knife(info);
        clonnedKnife.state.amount = state.amount;
        return clonnedKnife;
    }
}
