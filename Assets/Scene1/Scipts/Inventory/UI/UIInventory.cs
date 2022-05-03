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

    public UIInventoryTester tester;
    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new UIInventoryTester(_appleInfo, _papperInfo, _skullInfo, _keyInfo, _swordInfo, _keyFromPicInfo, uiSlots);
    }
}
