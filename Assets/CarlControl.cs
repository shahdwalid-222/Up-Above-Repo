using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlControl : MonoBehaviour
{
    public KeyCode R,L,sb;
    public float speed ,height;
    public Transform groundcheck;
    public float Groundcheckradius;
    public LayerMask WhatIsGround;
    private bool grounded ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(sb) && grounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x,height);
        }
        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void FixedUpdate(){
          grounded = Physics2D.OverlapCircle(groundcheck.position, Groundcheckradius, WhatIsGround ); 
    }
}
