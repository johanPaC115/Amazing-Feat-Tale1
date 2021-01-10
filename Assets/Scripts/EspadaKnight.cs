using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaKnight : MonoBehaviour
{
    KnightControl ctr;

    // Start is called before the first frame update
    void Start()
    {
        ctr = GameObject.Find("knight").GetComponent<KnightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("box"))
        {
            ctr.SetControlBox(collision.gameObject.GetComponent<controlBox>());
        }
        
    }
}
