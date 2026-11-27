using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTest : MonoBehaviour
{
        public AudioClip Damagesound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
         AudioScript.Instance.PlayMusicSFX(Damagesound);
        if(other.tag == "Player"){
            FindObjectOfType<PlayerStats>().TakeDamage(1);
    }
    }
}
