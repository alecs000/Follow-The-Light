using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool isActive;
    public void Open(GameObject menu)
    {
        if (!isActive)
        {
            menu.SetActive(true);
            isActive = true;
            return;
        }
        menu.SetActive(false);
        isActive = false;
    }
    public void Close(GameObject menu)
    {
        menu.SetActive(false);
        isActive = false;
    }
}
