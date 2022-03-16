using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    LevelManager levelManger;


    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManger = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer == null) return;
        PlayHitEffect();
        TakeDamage(damageDealer.GetDamage());
        ShakeCamera();
        damageDealer.Hit();
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        audioPlayer.PlayExplosionClip();

        if (health > 0) return;
        Die();
    }

    void Die()
    {
        
        if (!isPlayer) {
            scoreKeeper.ModifyScore(score);
        }else
        {  
            levelManger.LoadGameOver();
        }
        Destroy(gameObject);

    }
    void PlayHitEffect()
    {
        if (hitEffect == null) return;
        ParticleSystem instance =
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
    }

    void ShakeCamera()
    {
        if (cameraShake == null || !applyCameraShake) return;
        cameraShake.Play();
    }
}
