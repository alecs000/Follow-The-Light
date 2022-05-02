using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudBehavior : MonoBehaviour
{
    [SerializeField] Animator animText;
    [SerializeField] Animator animImage;
    [SerializeField] Text text;
    [SerializeField] float timeDisappear;
    bool firstEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void EnableCloud(string text)
    {
        this.text.text = text;
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
        StartCoroutine(DisableCloudCor());
    }
    IEnumerator DisableCloudCor()
    {
        yield return new WaitForSeconds(timeDisappear);
        DisableCloud();
    }
    private void DisableCloud()
    {
        animText.SetBool("DisAppear", false);
        animImage.SetBool("DisAppear", false);
        animText.SetBool("IsAppear", true);
        animImage.SetBool("IsAppear", true);
    }
}
