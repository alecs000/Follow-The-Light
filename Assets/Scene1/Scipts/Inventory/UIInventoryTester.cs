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
    private InventoryItemInfo _flashlight;
    private InventoryItemInfo _crutchInfo;
    private InventoryItemInfo _knifeInfo;
    private UIInventorySlot[] _uiSlots;
    public InventoryWithSlots inventory { get; }
    List<IInventorySlot> avalibleSlots;
    IInventorySlot[] allSlots;
    public UIInventoryTester(InventoryItemInfo appleInfo, InventoryItemInfo papperInfo, InventoryItemInfo skullInfo, InventoryItemInfo keyInfo,
        InventoryItemInfo swordInfo, InventoryItemInfo keyFromPicInfo, InventoryItemInfo flashlight, InventoryItemInfo crutchInfo, InventoryItemInfo knifeInfo, UIInventorySlot[] uiSlots)
    {
        _swordInfo = swordInfo;
        _keyInfo = keyInfo;
        _appleInfo = appleInfo;
        _papperInfo = papperInfo;
        _skullInfo = skullInfo;
        _keyFromPicInfo = keyFromPicInfo;
        _flashlight = flashlight;
        _crutchInfo = crutchInfo;
        _uiSlots = uiSlots;
        _knifeInfo = knifeInfo;
        inventory = new InventoryWithSlots(8);
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        allSlots = inventory.GetAllSlots();
        avalibleSlots = new List<IInventorySlot>(allSlots);
    }
    ///<summary>
    ///ключ от детской - 0
    ///ключи от кабинета - 1
    ///Skull - 2
    ///Key от гостинной - 3
    ///sword - 4
    ///KeyFromPic - 5
    ///Фонарь - 6
    ///костыль - 7
    ///кинжал - 8
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
            filledSlot = AddFlashlightIntoSlot(avalibleSlots);
        }
        if (numItem == 7)
        {
            filledSlot = AddCrutchIntoSlot(avalibleSlots);
        }
        if (numItem == 8)
        {
            filledSlot = AddKnifeIntoSlot(avalibleSlots);
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
    public void ClearSlot(string keyId)
    {
        foreach (var item in allSlots)
        {
            if (keyId == item?.item?.info?.id)
            {
                item.Clear();
                break;
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
    IInventorySlot AddFlashlightIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var flashlight = new Flashlight(_flashlight);
        flashlight.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, flashlight);
        return rSlot;
    }
    IInventorySlot AddCrutchIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var crutch = new Crutch(_crutchInfo);
        crutch.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, crutch);
        return rSlot;
    }
    IInventorySlot AddKnifeIntoSlot(List<IInventorySlot> slots)
    {
        var rSlot = slots[0];
        var knife = new Knife(_knifeInfo);
        knife.state.amount = 1;
        inventory.TryToAddToSlot(this, rSlot, knife);
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
