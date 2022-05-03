
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    [SerializeField] CloudBehavior cloud;
    [SerializeField] TriggerCloudActive trigger;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material lightMaterial;
    [SerializeField] Material shadowMaterial;
    [SerializeField] UIInventory uIInventory;
    [SerializeField] int numItem;
    [SerializeField] int timeClick = 1;
    [SerializeField] bool isRoom;
    [SerializeField] bool hide;
    [SerializeField] string keyId;
    int amountClick = 0;
    bool wasGet;
    private void Start()
    {
    }
    private void OnMouseEnter()
    {
        if (trigger.inTrigger)
        {
            sprite.material = lightMaterial;
            sprite.color = new Color(0.65f, 0.65f, 0.65f, 1);
        }
    }
    public void AddItem()
    {
        uIInventory.tester.FillSlots(numItem);
        wasGet = true;
        if (hide)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled= false;
        }
    }
    public void RemoveItem()
    {
        Debug.Log(2143324);
        uIInventory.tester.ClearSlots(keyId);
    }
    private void OnMouseDown()
    {
        if (trigger.inTrigger)
        {
            if (isRoom)
            {
                foreach (var item in uIInventory.inventory.GetAllItem())
                {
                    if (item.info.id == keyId)
                    {
                        if (keyId== "KeyLivingRoom")
                        {
                            cloud.transform.position = new Vector2(13, -13);
                        }
                    }
                }
            }
            amountClick++;
            if (!wasGet && amountClick== timeClick)
            {
                AddItem();
            }
        }
    }
    private void OnMouseExit()
    {
        if (trigger.inTrigger)
        {
            sprite.material = shadowMaterial;
            sprite.color = new Color(1f, 1f,1f, 1);
        }
    }
}
