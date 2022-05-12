using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public InventoryWithSlots inventory =>tester.inventory;
    [SerializeField] InventoryItemInfo _appleInfo;
    [SerializeField] InventoryItemInfo _papperInfo;
    [SerializeField] InventoryItemInfo _skullInfo;
    [SerializeField] InventoryItemInfo _keyInfo;
    [SerializeField] InventoryItemInfo _swordInfo;
    [SerializeField] InventoryItemInfo _keyFromPicInfo;
    [SerializeField] InventoryItemInfo _flashlight;
    [SerializeField] InventoryItemInfo _crutchInfo;
    [SerializeField] InventoryItemInfo _knifeInfo;
    public UIInventoryTester tester;
    public void StartInventory()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new UIInventoryTester(_appleInfo, _papperInfo, _skullInfo, _keyInfo, _swordInfo, _keyFromPicInfo, _flashlight, _crutchInfo, _knifeInfo, uiSlots);
        tester.FillSlots(6);
    }
}
