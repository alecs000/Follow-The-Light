using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flashlight : IInventoryItem
{
    public IInventoryItemInfo info { get; }

    public IInventoryItemState state { get; }

    public Type type => GetType();
    public Flashlight(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonnedFlashlight = new Flashlight(info);
        clonnedFlashlight.state.amount = state.amount;
        return clonnedFlashlight;
    }
}
