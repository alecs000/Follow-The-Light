using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool inCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollider = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
    }
}
