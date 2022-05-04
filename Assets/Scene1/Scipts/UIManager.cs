using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void Open()
    {
        menu.SetActive(true);
    }
    public void Close()
    {
        menu.SetActive(false);
    }
}
