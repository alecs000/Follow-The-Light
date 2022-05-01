using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlaerBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    void Start()
    {
    }
    void FixedUpdate()
    {
        MovementLogic();
    }
    private void MovementLogic()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * Input.GetAxis("Vertical"));
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
