using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqareBehavior : MonoBehaviour
{
    void Start()
    {
        RandomRotation();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void RandomRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 362));
    }
}
