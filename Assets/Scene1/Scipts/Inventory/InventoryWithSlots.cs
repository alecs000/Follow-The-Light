using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryWithSlots : IInventary
{
    public int capacity { get ; set ; }
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;
    public bool isFull => _slots.All(slot=>slot.isFull);
    List<IInventorySlot> _slots;
    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
            {
                allItems.Add(slot.item);
            }
        }
        return allItems.ToArray();
    }
    public InventoryWithSlots(int capacity)
    {
        this.capacity = capacity;
        _slots = new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }
    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).item;
    }
    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in slotsOfType)
        {
                allItemsOfType.Add(slot.item);
        }
        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var equiredItems = new List<IInventoryItem>();
        var requiredSlots = _slots.FindAll(slot => !slot.item.isEquipped);
        foreach (var slot in requiredSlots)
        {
            equiredItems.Add(slot.item);
        }
        return equiredItems.ToArray();
    }


    public int GetItemAmount(Type itemType)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => slot.isEmpty&& slot.itemType == itemType);
        foreach (var itemSlot in allItemSlots)
        {
            amount += itemSlot.amount;
        }
        return amount;
    }

    public bool HasItem(Type type, IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)
        {
            return;
        }
        var amountToRmove = amount;
        var count = slotsWithItem.Length;
        for (int i = count-1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.amount>= amountToRmove)
            {
                slot.item.amount -= amountToRmove;
                if (slot.amount <= 0)
                {
                    slot.Clear();
                }
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRmove);
                break;
            }
            var amountRempved = slot.amount;
            amountToRmove -= slot.amount;
            slot.Clear();
            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRmove);
        }
        
    }
    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }
    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.Find(slot => !slot.isEmpty && slot.itemType == item.type && !slot.isFull);
        if(slotWithSameItemButNotEmpty!=null)
        {
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);
        }
        var emptySlot = _slots.Find(slot => slot.isEmpty);
        if (emptySlot!=null)
        {
            return TryToAddToSlot(sender, emptySlot, item);
        }
        return false;
    }
    private bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.amount <= item.maxItemsInInventorySlot;
        var amountToAdd = fits ? item.amount : item.maxItemsInInventorySlot - slot.amount;
        var amountLeft = item.amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.amount = amountToAdd;
        if (slot.isEmpty)
        {
            slot.SetItem(clonedItem);
        }
        else
        {
            slot.item.amount += amountToAdd;
        }
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        if (amountLeft<=0)
        {
            return true;
        }
        item.amount = amountLeft;
        return TryToAdd(sender,item);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
