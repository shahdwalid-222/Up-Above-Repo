using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollectible : MonoBehaviour
{
    public AudioClip balloon;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerStats.score++;
            AudioScript.Instance.PlayMusicSFX(balloon);
            Debug.Log("Score: " + PlayerStats.score);
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
