using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryTester
{
    private InventoryItemInfo _appleInfo;
    private InventoryItemInfo _papperInfo;
    private UIInventorySlot[] _uiSlots;
    public InventoryWithSlots inventory { get; }
    List<IInventorySlot> avalibleSlots;
    IInventorySlot[] allSlots;
    public UIInventoryTester(InventoryItemInfo appleInfo,InventoryItemInfo papperInfo,UIInventorySlot[] uiSlots)
    {
        _appleInfo = appleInfo;
        _papperInfo = papperInfo;
        _uiSlots = uiSlots;
        inventory = new InventoryWithSlots(7);
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        allSlots = inventory.GetAllSlots();
        avalibleSlots = new List<IInventorySlot>(allSlots);
    }
    ///<summary>
    ///яблоко - 0
    ///Pepper - 1
    ///</summary>
    public void FillSlots(int numItem)
    {
        IInventorySlot filledSlot = new InventorySlot();
        Debug.Log(numItem);
        if (numItem == 0)
        {
            filledSlot = AddAppleIntoSlot(avalibleSlots);
        }
        if (numItem == 1)
        {
            filledSlot = AddPepperIntoSlot(avalibleSlots);
        }
        avalibleSlots.Remove(filledSlot);
        SetupInventoryUI(inventory);
    }
    private void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }

    IInventorySlot AddAppleIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var apple = new Apple(_appleInfo);
        apple.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, apple);
        return rSlot;

    }
    IInventorySlot AddPepperIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var papper = new Papper(_papperInfo);
        papper.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, papper);
        return rSlot;

    }
    IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var apple = new Apple(_appleInfo);
        apple.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, apple);
        return rSlot;

    }
    IInventorySlot AddRandomPappersIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        Debug.Log(rSlotIndex);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var papper = new Papper(_papperInfo);
        papper.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, papper);
        return rSlot;

    }
    void OnInventoryStateChanged(object sender)
    {
        foreach (var uiSlot in _uiSlots)
        {
            uiSlot.Refresh();
        }
    }
}
