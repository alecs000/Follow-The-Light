using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    public IInventorySlot slot { get; private set; }
    private UIInventory _uIInventory;
    [SerializeField] UIInventoryItem _uIInventoryItem;
    private void Awake()
    {
        _uIInventory = GetComponentInParent<UIInventory>();
        Refresh();
    }
    public void SetSlot(IInventorySlot newSlot)
    {
        slot = newSlot;
    }
    public override void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherSlotUI.slot;
        var inventory = _uIInventory.inventory;
        inventory.TrancitFromSlotToslot(this, otherSlot, slot);
        Refresh();
        otherSlotUI.Refresh();
    }
    public void Refresh()
    {
        if (slot!=null)
        {
            _uIInventoryItem.Refresh(slot);
        }
    }
}
