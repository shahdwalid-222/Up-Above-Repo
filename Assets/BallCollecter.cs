using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollecter : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite ballcollected;
    public AudioClip ballSound;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sr.sprite = ballcollected; // Change the ball sprite
            Destroy(gameObject, 0.2f); // Wait a fraction of a second and then destroy the ball
        }
            if(other.tag == "Player")
        {
            PlayerStats.score1++;
            AudioScript.Instance.PlayMusicSFX(ballSound);
            Debug.Log("Score: " + PlayerStats.score1);
        }
    }
}