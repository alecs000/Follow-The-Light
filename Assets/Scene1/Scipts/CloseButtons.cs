using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtons : MonoBehaviour
{
    public void Toogle(GameObject gm)
    {
        if (gm.activeInHierarchy)
        {
            gm.SetActive(false);
        }
        else
        {
            gm.SetActive(true);
        }
    }
}
