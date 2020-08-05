using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxControl : MonoBehaviour
{
    public int numGolpes = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GolpeKnight()
    {
        bool resp = false;
        numGolpes--;
        Debug.Log("Golpe: " + numGolpes);
        if (numGolpes <= 0)
        {
            resp = true;
            Destroy(gameObject, 0.5f);
        }
        return resp;
    }
}
