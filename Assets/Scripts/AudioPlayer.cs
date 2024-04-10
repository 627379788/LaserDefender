using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("shooting")]
    [SerializeField] AudioClip shootAudioClip;
    [SerializeField] [Range(0,1)] float shootAudioVolume;
    [Header("demage")]
    [SerializeField] AudioClip demageAudioClip;
    [SerializeField] [Range(0,1)] float demageAudioVolume;

    void Awake() {
        ManageSingleTon();
    }
    public void PlayShootAudio() {
        if(shootAudioClip != null) {
            PlayingAudio(shootAudioClip, shootAudioVolume);

        }
    }
    public void PlayDemageAudio() {
        if(demageAudioClip != null) {
           PlayingAudio(demageAudioClip, demageAudioVolume);
        }
    }

    void PlayingAudio(AudioClip audioClip, float volume) {
        if(audioClip != null) {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
    }
    void ManageSingleTon() {
        int len = FindObjectsOfType(GetType()).Length;
        if (len > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
