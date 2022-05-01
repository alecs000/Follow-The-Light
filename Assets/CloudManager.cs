using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] Animation animationImageAppear;
    [SerializeField] Animation animationTextAppear;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationTextAppear.Play();
            animationImageAppear.Play();
        }
    }
}
