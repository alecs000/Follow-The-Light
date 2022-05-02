using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloudActive : MonoBehaviour
{
    public bool inTrigger;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material shadowMaterial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.color = Color.white;
            sprite.material = shadowMaterial;
            inTrigger = false;
        }
    }

}
