using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xMax, yMax, xMin, yMin;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("knight").transform;
    }

     
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
