using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    static bool isActiveDialog;
    public void Close(GameObject gm)
    {
        gm.SetActive(false);
        isActiveDialog = false;
    }
    public void Open(GameObject gm)
    {
        gm.SetActive(true);
        isActiveDialog = true;
    }
    public void Toggle(GameObject gm)
    {
        if (isActiveDialog)
        {
            gm.SetActive(false);
            isActiveDialog = false;
        }
        else
        {
            gm.SetActive(true);
            isActiveDialog = true;
        }
    }
}
