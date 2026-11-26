using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlControl : MonoBehaviour
{

    private Animator anim;
    // private bool isRolling = false,isHit = false,isThrow = false;
    private bool isActive= false;
    public KeyCode R,L,sb,roll,H,T,C;
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


         if (Input.GetKeyDown(roll) && !isActive && !anim.GetBool("isDamage"))
        {
            isActive = true;
            anim.SetTrigger("Roll");
        }

        if(Input.GetKeyDown(H) && !isActive){
            isActive = true;
            anim.SetTrigger("Hit");
        }

        if(Input.GetKeyDown(T) && !isActive && !anim.GetBool("isDamage")){
            isActive = true;
            anim.SetTrigger("Throw");
        }    

        // if(Input.GetKey(C) && grounded && !anim.GetBool("isDamage")){
        //     anim.SetBool("Crouch",true);
        //     if(Input.GetKey(L)){
        //         anim.SetBool("Crawl",true);
        //         GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * 0.4f, GetComponent<Rigidbody2D>().velocity.y);
        //     if(GetComponent<SpriteRenderer>() != null){
        //      GetComponent<SpriteRenderer>().flipX = false;} 
        //     }
        //     else if(Input.GetKey(R)){
        //         anim.SetBool("Crawl",true);
        //         GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 0.4f, GetComponent<Rigidbody2D>().velocity.y);
        //     if(GetComponent<SpriteRenderer>() != null){
        //      GetComponent<SpriteRenderer>().flipX = true;} 
        //     }
        
        // }
    
        bool crouching = Input.GetKey(C) && grounded && !anim.GetBool("isDamage");
anim.SetBool("Crouch", crouching);
anim.SetBool("Crawl", crouching && (Input.GetKey(L) || Input.GetKey(R)));

if (crouching)
{
  anim.SetBool("Crouch",true);
            if(Input.GetKey(L)){
                anim.SetBool("Crawl",true);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * 0.4f, GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>() != null){
             GetComponent<SpriteRenderer>().flipX = false;} 
            }
            else if(Input.GetKey(R)){
                anim.SetBool("Crawl",true);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 0.4f, GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>() != null){
             GetComponent<SpriteRenderer>().flipX = true;} 
            }
}



            anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            anim.SetBool("Grounded", grounded);   
     }

    void FixedUpdate(){
          grounded = Physics2D.OverlapCircle(groundcheck.position, Groundcheckradius, WhatIsGround ); 
    }



     public void TakeDamage()
    {
        if (anim.GetBool("isDamage") || isActive)
            return;

        anim.SetBool("isDamage",true);  
        
    }

    //  public void EndRoll()
    // {
    //     isRolling = false;
    // }

    public void end(){
        isActive = false;
    }

    public void EndDamage()
    {
        anim.SetBool("isDamage" , false);
    }


    //  public void EndHit()
    // {
    //     isHit = false;
    // }

    // public void EndThrow()
    // {
    //     isThrow = false;
    // }
}
