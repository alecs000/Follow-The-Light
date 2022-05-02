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
    bool wasGet;
    private void OnMouseEnter()
    {
        if (trigger.inTrigger)
        {
            sprite.material = lightMaterial;
            sprite.color = new Color(0.65f, 0.65f, 0.65f, 1);
        }
    }
    private void OnMouseDown()
    {
        if (trigger.inTrigger)
        {
            if (!wasGet)
            {
                uIInventory.tester.FillSlots(numItem);
                wasGet = true;
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
