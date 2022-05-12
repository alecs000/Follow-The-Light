using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavopr : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
