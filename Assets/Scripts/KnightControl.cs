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

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadio;

    [SerializeField]
    private LayerMask whatIsGrond;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    private Animator myAnimator;

    [SerializeField]
    private int vidas;

    [SerializeField]
    private Text txtVidas;

    public Slider slider;
    public Text txt;


    public int energy = 100;
    public int GolpeAire = 1;
    public int GolpeBox = 3;
    public int PremioHeart = 15;



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

        /*  if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f )
          {
              myAnimator.SetTrigger("attack1");
              if (ctrBox != null)
                  ctrBox.GolpeKnight();                        
          }*/

        slider.value = energy;
        txt.text = energy.ToString();
        txtVidas.text = vidas.ToString();
    }


    void FixedUpdate()
    {
        /*Movimiento Horizontal*/
        float H = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(H);

        Flip(H);

        HandleAttacks();

        HandleLayers();

        ResetValues();


    }

    private void HandleMovement(float h)
    {
        if (myRigidbody.velocity.y <0)
        {
            myAnimator.SetBool("land", true);
        }
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack1"))
        {
            myRigidbody.velocity = new Vector2(h * movementSpeed, myRigidbody.velocity.y);
        }
        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
        }

        myAnimator.SetFloat("speed", Mathf.Abs(h));
    }

    private void HandleAttacks()
    {
        if (attack1 && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack1"))
        {
            myAnimator.SetTrigger("attack1");
            myRigidbody.velocity = Vector2.zero;
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !isRight || horizontal < 0 && isRight)
        {
            isRight = !isRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void ResetValues()
    {
        attack1 = false;
        jump = false;
    }

    private bool IsGrounded()
    {
        if(myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadio, whatIsGrond);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                       myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1,0);
        }
    }

    public void SetControlBox(boxControl ctr)
    {
        ctrBox = ctr;
    }
}
