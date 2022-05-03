using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Key : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Key(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedKey = new Key(info);
        clonnedKey.state.amount = state.amount;
        return clonnedKey;
    }
}
