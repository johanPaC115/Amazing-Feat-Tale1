using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightControl : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementSpeed;

    private bool attack1;

    private bool isRight;
    private Animator myAnimator;
    
    

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
        isRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

     void Update()
    {
        HandleInput();

        if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f )
        {
            myAnimator.SetTrigger("ataque1");
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

        HandleMovement(H);

        Flip(H);

        HandleAttacks();

        
        /*Movimineto Vertical*/
        float V = Input.GetAxis("Vertical");
        Vector2 sal = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        sal.y = V;
        myRigidbody.velocity = sal;

        /*Ataque Base
        // float ataqueBase = Input.GetAxis("fire1");
        // Debug.Log("Ataque: " + ataqueBase);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ataque1();
        }*/
    }

    private void HandleMovement(float h)
    {
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack1"))
        {
            myRigidbody.velocity = new Vector2(h * movementSpeed, myRigidbody.velocity.y);
        }
        
        myAnimator.SetFloat("speed", Mathf.Abs(h));
    }

    private void HandleAttacks()
    {
        if (attack1 && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack1"))
        {
            myAnimator.SetTrigger("attack1");
            attack1 = !attack1;
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack1 = true;
        }
    }
    void Flip(float horizontal)
    {
        if(horizontal > 0 && !isRight || horizontal < 0 && isRight) 
        { 
        isRight = !isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        }
    }

    void ataque1()
    {
        myAnimator.SetTrigger("ataque1");
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
