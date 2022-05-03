
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
    [SerializeField] int[] numItem;
    [SerializeField] int timeClick = 1;
    [SerializeField] bool isRoom;
    [SerializeField] bool hide;
    [SerializeField] string keyId;
    [SerializeField] bool inLivihRoom =true;
    [SerializeField] AudioSource source;
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
        foreach (var item in numItem)
        {
            uIInventory.tester.FillSlots(item);
            wasGet = true;
            if (hide)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
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
                        source.Play();
                        if (keyId== "KeyLivingRoom"&& inLivihRoom)
                        {
                            cloud.transform.position = new Vector2(13, -13);
                            break;
                        }
                        if (keyId == "KeyLivingRoom"&& !inLivihRoom)
                        {
                            cloud.transform.position = new Vector2(-3, 1.7f);
                            break;
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
