using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    [SerializeField] GameObject gm;
    [SerializeField] GameObject cam;
    Vector3 pos;
    public void Active()
    {
        pos = cam.transform.position;
        gm.SetActive(true);
        cam.GetComponent<CameraFollow2D>().enabled = false;
        cam.transform.position =new Vector3(39.9000015f, 25.7999992f, -6.71000004f);
    }
    public void Disactive()
    {
        gm.SetActive(false);
        cam.GetComponent<CameraFollow2D>().enabled = true;
        cam.transform.position = pos;
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Active();
    //    }
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        Disactive();
    //    }
    //}
}
