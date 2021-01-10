using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBox : MonoBehaviour
{
    [SerializeField]
    private int numGolpes = 8;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GolpePlayer()
    {
        bool resp = false;
        --numGolpes;
        if (numGolpes <= 2) {
            animator.SetBool("golpeOne", true);
            if (numGolpes<=0)
            {
                animator.SetBool("golpeOne", false);
                animator.SetBool("golpeTwo", true);
                resp = true;
                Destroy(gameObject, .9f);
            }
        }
        Debug.Log("Respuesta: "+resp);
        return resp;       
    }
}
