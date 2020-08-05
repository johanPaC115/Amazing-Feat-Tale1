using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightControl : MonoBehaviour
{
    Rigidbody2D rgb;
    Animator anim;
    public int maxVel=3;
    bool isDer = true;

    public Slider slider;
    public Text txt;

    public int energy = 100;
    public int GolpeAire = 1;
    public int GolpeBox = 3;
    public int PremioHeart = 15;

    bool enFire1 = false;

    boxControl ctrBox = null;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

     void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f )
        {
            anim.SetTrigger("ataque1");
            if (ctrBox != null)
                ctrBox.GolpeKnight();                        
        }
            
        slider.value = energy;
        txt.text = energy.ToString();
    }


    void FixedUpdate()
    {
        /*Movimiento Horizontal*/
        float H =Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        H *= maxVel;
        vel.x = H;
        rgb.velocity = vel;
        anim.SetInteger("vel", (int)vel.x);
        if (isDer && H < 0)
        {         
            Flip();
        }else if (!isDer && H > 0)
        {         
            Flip();
        }
        /*Movimineto Vertical*/
        float V = Input.GetAxis("Vertical");
        Vector2 sal = new Vector2(rgb.velocity.x, rgb.velocity.y);
        sal.y = V;
        rgb.velocity = sal;

        /*Ataque Base
        // float ataqueBase = Input.GetAxis("fire1");
        // Debug.Log("Ataque: " + ataqueBase);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ataque1();
        }*/
    }

    void Flip()
    {
        isDer = !isDer;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void ataque1()
    {
        anim.SetTrigger("ataque1");
    }

    public bool isAttack1()
    {
        return enFire1;
    }

    public void SetControlBox(boxControl ctr)
    {
        ctrBox = ctr;
    }
}
