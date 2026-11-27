using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;

    void Start()
    {
        CurrentCheckpoint = null;
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        CarlControl player = FindObjectOfType<CarlControl>();

        if (player != null && CurrentCheckpoint != null)
        {
            player.transform.position = CurrentCheckpoint.transform.position;
        }
    }
}