
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
    [SerializeField] bool itIsRemove;
    [SerializeField] int[] numItem;
    [SerializeField] int timeClick = 1;
    [SerializeField] bool isRoom;
    [SerializeField] string keyId;
    [Tooltip("0 - хол; 1 - гостинная")]
    [SerializeField] int onRoomNum;
    [SerializeField] GameObject canvasAnim;
    Animation anim;
    [SerializeField] GameObject cam;
    [SerializeField] AudioSource audioSource;
    int amountClick = 0;
    bool wasGet;
    private void Start()
    {
        if (isRoom)
        {
            anim = canvasAnim.GetComponent<Animation>();
        }
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
        }
    }
    public void RemoveItem()
    {
        uIInventory.tester.ClearSlot(keyId);
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
                        audioSource.Play();
                        anim.Play();
                            if (onRoomNum == 0)
                            {
                                cloud.transform.position = new Vector2(-3, 1.7f);
                            cam.transform.position = new Vector2(-3, 1.7f);
                            break;
                            }
                            if (onRoomNum==1)
                            {
                                cloud.transform.position = new Vector2(13, -13);
                            cam.transform.position = new Vector2(13, -13);
                            break;
                            }
                        if (onRoomNum == 2)
                        {
                            cloud.transform.position = new Vector2(33.6f, 2.35f);
                            cam.transform.position = new Vector2(33.6f, 2.35f);
                            break;
                        }
                        if (onRoomNum == 3)
                        {
                            cloud.transform.position = new Vector2(12.2f, 20.89f);
                            cam.transform.position = new Vector2(12.2f, 20.89f);
                            break;
                        }
                    }
                }
            }
            if ((itIsRemove))
            {
                RemoveItem();
            }
            else
            {
                amountClick++;
                if (!wasGet && amountClick == timeClick)
                {
                    AddItem();
                }
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
