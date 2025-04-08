using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private int currentLevel;
    private AudioSource audioSource;
    public static SoundController instance;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Awake()
    {
        if (instance != null)
        {

            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void PlaySound(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayLoop(AudioClip clip)
    {
        if(clip)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }

    }

     public static SoundController FindSoundController()
    {
        var soundController = FindObjectOfType<SoundController>();
        if (!soundController)
        {
            Debug.LogWarning("No Sound Controller Found, no sounds will play");
        }
        return soundController;
    }



}
