using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private Animator anim;
    private bool isActive= false;
    private bool grounded ;
    public float speed;
    private int health=10;
    private int hearts=5;
    public static int score =0; //balloon score
    public static int score1 =0; //balls score
    public Image FullHeart;
    private float flickerTime =0f; //between sprite visibility toggles during immunity
    private float flickerDuration =0.1f; //before toggling again to create the blinking
    private SpriteRenderer sr; 
    public bool isImmune = false;
    private float immunityTime =0f; //how long the player has been immune since getting hit.
    private float immunityDuration = 1f; //duration of blinking before isImmune turning false 
    public TextMeshProUGUI BallonscoreUI,BallsscoreUI;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         
         if (isImmune==true)
         {
            spriteFlicker();
             immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >=immunityDuration)
            {
                isImmune=false;
                sr.enabled=true;
            }
         }
          BallonscoreUI.text = " " + score;
          BallsscoreUI.text = " " + score1;
    } 

    void spriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime+ Time.deltaTime;
        }
        else if (flickerTime>=flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            flickerTime=0;
        }
    }

     public void TakeDamage(int damage)
    {
        if (anim.GetBool("isDamage") || isActive)
        {
            return;
        }
        anim.SetBool("isDamage",true);
        
        if (isImmune == false)
    {
        health = health-damage;
        if (health<0) 
            health=0;
            hearts = (health + 1) / 2;
            FullHeart.fillAmount= this.health/10f;
        if(hearts>0 && health==0)
        {
            FindObjectOfType<LevelManager>().RespawnPlayer();
            health=2; 
            FullHeart.fillAmount= this.health/10f;
            hearts--;
        }
        else if (hearts==0 && health==0)
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
        Debug.Log("Player Health:" + health.ToString());
        Debug.Log("Player Hearts:" + hearts.ToString());  
    }
        isImmune=true;
        immunityTime=0f;
    }
    
   

    public void EndDamage()
    {
        anim.SetBool("isDamage" , false);
    }
}
