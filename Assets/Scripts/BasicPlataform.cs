using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlataform : MonoBehaviour
{

    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D plataformCollider;

    [SerializeField]
    private BoxCollider2D plataformTrigger;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.Find("knight").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(plataformCollider, plataformTrigger, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="knight")
        {
            Physics2D.IgnoreCollision(plataformCollider, playerCollider, true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "knight")
        {
            Physics2D.IgnoreCollision(plataformCollider, playerCollider, false);
        }
    }
}
