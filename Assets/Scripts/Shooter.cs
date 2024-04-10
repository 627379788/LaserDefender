using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    [Header("generation")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float basefiringRate = 0.2f;

    [Header("Enemy")]
    [SerializeField] bool isAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [HideInInspector]public bool isFiring;
    Coroutine firingCorouting;
    AudioPlayer audioPlayer;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() {
        isFiring = isAI;
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCorouting == null) {
            firingCorouting = StartCoroutine(FireContinuously());
        }else if(!isFiring && firingCorouting != null) {
            StopCoroutine(firingCorouting);
            firingCorouting = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
            if(rigidbody2D != null) {
                rigidbody2D.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            audioPlayer.PlayShootAudio();
            float timeToNextProjectile = UnityEngine.Random.Range(basefiringRate - firingRateVariance, basefiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
