using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] Trigger trigger;
    [SerializeField] SqareBehavior squareBehavior;
    [SerializeField] Flowchart flowchart;
    int shot = 0;
    int time = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(shot);
            time++;
            if (time < 11)
            {
                if (trigger.inCollider)
                {
                    shot++;
                    squareBehavior.RandomRotation();
                }
                else
                {
                    squareBehavior.RandomRotation();
                }
            }
            if (time == 10 && shot > 6)
            {
                flowchart.ExecuteBlock("MindBreak");
            }
        }

    }
}
