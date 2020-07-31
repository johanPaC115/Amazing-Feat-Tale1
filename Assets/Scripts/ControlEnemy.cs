using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public float vel = 1f;
    Rigidbody2D rgb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // 
    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity = v;
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("walk")&& Random.value < 1f / (60f * 3f))
        {
            anim.SetTrigger("parar");
            parar();
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Random.value < 1f / (60f * 3f))
        {
            anim.SetTrigger("caminar");
            caminar(); 
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Flip();
    }

    void Flip()
    {
        vel *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void parar()
    {
        
        vel = 0;
    }

    void caminar()
    {
        
        var s = transform.localScale.x;
        s  /= 2.5f;
        vel = s;
    }
}
