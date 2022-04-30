using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject closeDoor;
    [SerializeField] GameObject openDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(999);
        if (collision.gameObject.CompareTag("Player"))
        {
            closeDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}
