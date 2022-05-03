using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlaerBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    bool stop;
    void Start()
    {
    }
    void FixedUpdate()
    {
        if (!stop)
        {
            MovementLogic();
        }
    }
    public void StopPlaer()
    {
        stop = true;
    }
    public void PushPlaer()
    {
        stop = false;
    }
    private void MovementLogic()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vertic = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horiz) > 0)
        {
            rb.velocity = new Vector2(horiz, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Mathf.Abs(vertic) > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * vertic);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (horiz>0)
        {
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("forward", false);
            anim.SetBool("back", false);
        }
        else if (horiz < 0)
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("forward", false);
            anim.SetBool("back", false);
        }
        else if (vertic>0)
        {
            anim.SetBool("back", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("forward", false);
        }
        else if (vertic < 0)
        {
            anim.SetBool("forward", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("back", false);
        }
        else
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("forward", false);
            anim.SetBool("back", false);
        }
    }
}
