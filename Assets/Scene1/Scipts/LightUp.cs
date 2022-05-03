using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    [SerializeField] GameObject lightGM;
    public void UpLight()
    {
        lightGM.SetActive(true);
    }
    public void DownLight()
    {
        lightGM.SetActive(false);
    }
}
