using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emergirLava : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
        rb.velocity = new Vector2(0, 0.5f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
