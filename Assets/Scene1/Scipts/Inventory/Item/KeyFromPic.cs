using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFromPic : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public KeyFromPic(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedKeyFromPic = new KeyFromPic(info);
        clonnedKeyFromPic.state.amount = state.amount;
        return clonnedKeyFromPic;
    }
}
