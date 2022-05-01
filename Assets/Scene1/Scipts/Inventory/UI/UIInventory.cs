using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public InventoryWithSlots inventory =>tester.inventory;
    [SerializeField] InventoryItemInfo _appleInfo;
    [SerializeField] InventoryItemInfo _papperInfo;

    UIInventoryTester tester;
    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new UIInventoryTester(_appleInfo, _papperInfo, uiSlots);
        tester.FillSlots();
    }
}
