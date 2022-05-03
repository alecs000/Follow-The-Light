using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryTester
{
    private InventoryItemInfo _appleInfo;
    private InventoryItemInfo _papperInfo;
    private InventoryItemInfo _skullInfo;
    private InventoryItemInfo _keyInfo;
    private InventoryItemInfo _swordInfo;
    private InventoryItemInfo _keyFromPicInfo;
    private InventoryItemInfo _keyFrom—hildren;
    private UIInventorySlot[] _uiSlots;
    public InventoryWithSlots inventory { get; }
    List<IInventorySlot> avalibleSlots;
    IInventorySlot[] allSlots;
    public UIInventoryTester(InventoryItemInfo appleInfo,InventoryItemInfo papperInfo, InventoryItemInfo skullInfo, InventoryItemInfo keyInfo, InventoryItemInfo swordInfo, InventoryItemInfo keyFromPicInfo, InventoryItemInfo keyFrom—hildren, UIInventorySlot[] uiSlots)
    {
        _swordInfo = swordInfo;
        _keyInfo = keyInfo;
        _appleInfo = appleInfo;
        _papperInfo = papperInfo;
        _skullInfo = skullInfo;
        _keyFromPicInfo = keyFromPicInfo;
        _keyFrom—hildren = keyFrom—hildren;
        _uiSlots = uiSlots;
        inventory = new InventoryWithSlots(7);
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        allSlots = inventory.GetAllSlots();
        avalibleSlots = new List<IInventorySlot>(allSlots);
    }
    ///<summary>
    ///ﬂ·ÎÓÍÓ - 0
    ///Pepper - 1
    ///Skull - 2
    ///Key - 3
    ///sword - 4
    ///KeyFromPic - 5
    ///KeyFrom—hildren - 6
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
        if (numItem == 2)
        {
            filledSlot = AddSkullIntoSlot(avalibleSlots);
        }
        if (numItem == 3)
        {
            filledSlot = AddKeyIntoSlot(avalibleSlots);
        }
        if (numItem == 4)
        {
            filledSlot = AddSwordIntoSlot(avalibleSlots);
        }
        if (numItem == 5)
        {
            filledSlot = AddKeyFromPicIntoSlot(avalibleSlots);
        }
        if (numItem == 6)
        {
            filledSlot = AddKeyFrom—hildrenPicIntoSlot(avalibleSlots);
        }
        avalibleSlots.Remove(filledSlot);
        SetupInventoryUI(inventory);
    }
    public void ClearSlots(string keyId)
    {
        foreach (var item in allSlots)
        {
            if (keyId == item?.item?.info?.id)
            {
                item.Clear();
            }
        }
        avalibleSlots.Add(new InventorySlot());
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
    IInventorySlot AddSkullIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var skull = new Skull(_skullInfo);
        skull.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, skull);
        return rSlot;
    }
    IInventorySlot AddKeyIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var key = new Key(_keyInfo);
        key.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, key);
        return rSlot;
    }
    IInventorySlot AddSwordIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var sword = new Sword(_swordInfo);
        sword.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, sword);
        return rSlot;
    }
    IInventorySlot AddKeyFromPicIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var keyFromPic = new KeyFromPic(_keyFromPicInfo);
        keyFromPic.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, keyFromPic);
        return rSlot;
    }
    IInventorySlot AddKeyFrom—hildrenPicIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var keyFrom—hildren = new KeyFrom—hildren(_keyFrom—hildren);
        keyFrom—hildren.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, keyFrom—hildren);
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
