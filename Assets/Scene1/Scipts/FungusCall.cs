using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class FungusCall : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flowchart.ExecuteBlock("a1");
        }
    }
}
