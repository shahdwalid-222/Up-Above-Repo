using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip MarriedLife;  
    // Start is called before the first frame update
    void Awake()
{
    if(Instance == null){
        Instance=this;
        DontDestroyOnLoad(gameObject);
    }
    else
    Destroy(gameObject);
}
    void Start()
    {
      musicSource.clip= MarriedLife;
      musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusicSFX(AudioClip clip)
    {
        sfxSource.clip=clip;
        sfxSource.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip=clip;
        musicSource.Play();
    }

}
