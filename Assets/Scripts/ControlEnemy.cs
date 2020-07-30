using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public float vel = -1f;
    Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

    }

    // 
    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity = v;

    }
}
