using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int healthValue = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool isCameraShake;
    int score = 50;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    ScenesManage scenesManage;
    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scenesManage = FindObjectOfType<ScenesManage>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            DamageHealth(damageDealer.GetDamageValue());
            PlayHitEffect();
            damageDealer.Hit();
        }
    }
    public int GetHealthValue() {
        return healthValue;
    }

    private void DamageHealth(int damageValue)
    {
        healthValue -= damageValue;
        if (healthValue <= 0) {
            DieAirplane();
        }
        ShakeCamera();
        audioPlayer.PlayDemageAudio();
    }

    private void DieAirplane()
    {
        if(!isPlayer) {
            scoreKeeper.SetCurrentScore(score);
        }else {
            scenesManage.LoadGameOver();
        }
        Destroy(gameObject);
    }

    private void ShakeCamera()
    {
       if(cameraShake != null && isCameraShake) {
            cameraShake.Play();
       }
    }

    void PlayHitEffect() {
        if (hitEffect != null) {
            ParticleSystem particleSystem = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(particleSystem.gameObject, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
        }
    }
}
