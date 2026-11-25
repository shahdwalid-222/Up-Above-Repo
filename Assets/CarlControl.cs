using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlControl : MonoBehaviour
{

    private Animator anim;
    private bool isRolling = false;
    private bool isDamaged = false;

    public KeyCode R,L,sb;
    public float speed ,height;
    public Transform groundcheck;
    public float Groundcheckradius;
    public LayerMask WhatIsGround;
    private bool grounded ;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(sb) && grounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x,height);
        }
        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>() != null)
        {
    GetComponent<SpriteRenderer>().flipX = false;
        }    
       
        }
        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if(GetComponent<SpriteRenderer>() != null)
        {
    GetComponent<SpriteRenderer>().flipX = true;
        }    
        }


         if (Input.GetKeyDown()
            && !isRolling && !isDamaged)
        {
            isRolling = true;
            animator.SetTrigger("Roll");
        }

            anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            anim.SetBool("Grounded", grounded);   
     }

    void FixedUpdate(){
          grounded = Physics2D.OverlapCircle(groundcheck.position, Groundcheckradius, WhatIsGround ); 
    }
}
