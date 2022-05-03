using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyFromСhildren : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public KeyFromСhildren(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedKeyFromСhildren = new KeyFromСhildren(info);
        clonnedKeyFromСhildren.state.amount = state.amount;
        return clonnedKeyFromСhildren;
    }
}
