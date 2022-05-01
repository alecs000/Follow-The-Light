using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    [SerializeField] Animator animText;
    [SerializeField] Animator animImage;
    bool firstEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableCloud();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisableCloud();
        }
    }
    private void EnableCloud()
    {
        if (firstEnable)
        {
            animText.SetBool("IsAppear", true);
            animImage.SetBool("IsAppear", true);
            animText.SetBool("DisAppear", true);
            animImage.SetBool("DisAppear", true);
            firstEnable = false;
        }
        else
        {
            animText.SetBool("IsAppear", false);
            animImage.SetBool("IsAppear", false);
            animText.SetBool("DisAppear", true);
            animImage.SetBool("DisAppear", true);
        }
    }
    private void DisableCloud()
    {
        animText.SetBool("DisAppear", false);
        animImage.SetBool("DisAppear", false);
        animText.SetBool("IsAppear", true);
        animImage.SetBool("IsAppear", true);
    }
}
