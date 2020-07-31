using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightControl : MonoBehaviour
{
    Rigidbody2D rgb;
    Animator anim;
    public int maxVel=3;
    bool isDer = true;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        float v =Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rgb.velocity = vel;
        anim.SetInteger("vel", (int)vel.x);
        if (isDer && v < 0)
        {
            isDer = false;
            Flip();
        }else if (!isDer && v > 0)
        {
            isDer = true;
            Flip();
        }
    }

    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
