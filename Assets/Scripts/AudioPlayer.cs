using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)]  float shootingVolume = 0.5f;


    [Header("Explosion")]
    [SerializeField] AudioClip explosionCLip;
    [SerializeField][Range(0f, 1f)] float explosionVolume = 0.5f;

    static AudioPlayer instance;


    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        
        if (instance != null){
            gameObject.SetActive(false);//UnityThings
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        };
        
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionCLip, explosionVolume);
    }

    void PlayClip(AudioClip clip,float volume)
    {
        if (clip == null) return;
        Vector3 position = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

}
